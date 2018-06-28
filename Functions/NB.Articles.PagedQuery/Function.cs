using Amazon.Lambda.Core;
using NB.Shared.BasicClasses;
using NB.Shared.BasicClasses.Category;
using NB.Shared.BasicClasses.Enum;
using System;
using System.Data.SqlClient;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace NB.Articles.PagedQuery
{
    public class Filter : FilterBase
    {
        public DocumentType DocumentType { get; set; }
        public Language Language { get; set; }
    }
    public class Function
    {
        /// <summary>
        /// Used to show the most recent articles on the home page.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Entire articles</returns>
        public PagedResult<Document> FunctionHandler(Filter filter, ILambdaContext context)
        {
            // Errors
            // PageSize < 1
            // PageIndex < 1
            var strCon = "Server=nightlyberry.cqm4dbzoplhr.us-east-1.rds.amazonaws.com;Database=nb_dev;User Id=nightlyberry;Password = gdmdu3D29!;";

            var sql = @"select D.Id, D.CategoryId, D.CreatedAt, DC.Text, DC.Title, total_count = COUNT(*) OVER()
                        from Document D
                        join DocumentContent DC on D.Id = DC.DocumentId and DC.LanguageId = @languageId
                        where D.DocumentTypeId = @documentTypeId
                        order by CreatedAt desc
                        offset @offset rows fetch next @fetch rows only;";

            var result = new PagedResult<Document>(filter);

            using (var connection = new SqlConnection(strCon))
            {
                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@languageId", (int)filter.Language);
                command.Parameters.AddWithValue("@documentTypeId", (int)filter.DocumentType);
                command.Parameters.AddWithValue("@offset", (filter.PageIndex - 1) * filter.PageSize);
                command.Parameters.AddWithValue("@fetch", filter.PageSize);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Items.Add(new Document
                        {
                            Id = (int)reader[0],
                            Parent = new CategoryComposite("", (int)reader[1]),
                            CreatedAt = Convert.ToDateTime(reader[2]),
                            Content = reader[3].ToString(),
                            Name = reader[4].ToString(),
                            DocumentType = filter.DocumentType,
                            Language = filter.Language
                        });

                        if (result.TotalItems == -1)
                            result.TotalItems = (int)reader[5];
                    }
                }
            }

            return result;
        }
    }
}
