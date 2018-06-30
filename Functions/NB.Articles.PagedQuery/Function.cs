using Amazon.Lambda.Core;
using NB.Shared.BasicClasses;
using NB.Shared.BasicClasses.Category;
using NB.Shared.BasicClasses.Enum;
using NB.Shared.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

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
        static SqlCommand _command;

        async Task<SqlCommand> GetCommand()
        {
            if(_command == null)
            {
                var connection = new SqlConnection(await new Configuration().Get(ConfigurationItem.ConnectionString));

                _command = new SqlCommand(
                    @"select D.Id, D.CategoryId, D.CreatedAt, DC.Text, DC.Title, total_count = COUNT(*) OVER()
                from Document D
                join DocumentContent DC on D.Id = DC.DocumentId and DC.LanguageId = @languageId
                where D.DocumentTypeId = @documentTypeId
                order by CreatedAt desc
                offset @offset rows fetch next @fetch rows only;", connection);

                _command.Parameters.Add("@languageId", SqlDbType.Int);
                _command.Parameters.Add("@documentTypeId", SqlDbType.Int);
                _command.Parameters.Add("@offset", SqlDbType.Int);
                _command.Parameters.Add("@fetch", SqlDbType.Int);

                try
                {
                    connection.Open();
                }
                catch
                {
                    Console.WriteLine("[NB.Articles.PagedQuery] Something bad happened during the connection opening");
                    throw;
                }
            }

            return _command;
        }

        /// <summary>
        /// Used to show the most recent articles on the home page.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Entire articles</returns>
        public async Task<PagedResult<Document>> FunctionHandler(Filter filter, ILambdaContext context)
        {
            // Errors
            // PageSize < 1
            // PageIndex < 1
            var command = await GetCommand();
            command.Parameters["@languageId"].Value = (int)filter.Language;
            command.Parameters["@documentTypeId"].Value = (int)filter.DocumentType;
            command.Parameters["@offset"].Value = (filter.PageIndex - 1) * filter.PageSize;
            command.Parameters["@fetch"].Value = filter.PageSize;

            var result = new PagedResult<Document>(filter);

            try
            {
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
            catch
            {
                Console.WriteLine("[NB.Articles.PagedQuery] Something bad happened during the command execution");
                throw;
            }
            
            return result;
        }
    }
}
