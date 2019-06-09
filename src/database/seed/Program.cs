using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Seed
{
    class Program
    {
        const int NAME = 1;
        const int PARENT = 3;
        const int START = 4;
        const int END = 5;
        const int LINK = 7;
        const string NULL = "null";

        private static readonly string[] csvDateFormatters = new string[] { "yyyy", "yyyy.M", "yyyy.M.d" };

        static void Main(string[] args)
        {
            var con = new SqlConnection("Server=localhost;Database=distro-guide;Trusted_Connection=True;");
            var command = con.CreateCommand();

            try
            {
                con.Open();

                using (var reader = new StreamReader("gldt.csv"))
                {
                    var cache = new List<KeyValuePair<Guid, string>>();

                    while (!reader.EndOfStream)
                    {
                        string[] line = GetLine(reader);
                        var isNotNode = line[0] != "N";
                        if (isNotNode)
                            continue;

                        var distroGuid = Guid.NewGuid();
                        cache.Add(new KeyValuePair<Guid, string>(distroGuid, line[NAME]));

                        var parentId = GetNullable(line[PARENT], () => cache.Last(c => c.Value == line[PARENT]).Key.ToString());

                        var start = GetNullable(line[START], () => ToMySQLDate(line[START]));
                        var end = GetNullable(line[END], () => ToMySQLDate(line[END]));

                        var insert = $@"insert into Distro 
                        ([Id], [Name], [BasedOnId], [Start], [End])
                        values 
                        ('{distroGuid}','{line[NAME]}',{parentId},{start},{end})";

                        command.CommandText = insert;
                        command.ExecuteNonQuery();

                        insert = $@"insert into ExternalReference
                        (Id, TargetId, ExternalReferenceTypeId, Reference, IsPrincipal)
                        values
                        ('{Guid.NewGuid()}', '{distroGuid}', 'e35182b6-e94d-4866-988f-efbba491b994', '{line[LINK]}', 1)";

                        command.CommandText = insert;
                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private static string GetNullable(string value, Func<string> transform = null)
        {
            return value == string.Empty
                ? NULL
                : $"'{(transform == null ? value : transform())}'";
        }

        private static string ToMySQLDate(string csvDate)
        {
            if (csvDate.EndsWith(".00"))
                csvDate = csvDate.Replace(".00", string.Empty);

            var nSeparators = csvDate.Count(c => c == '.');

            return DateTime
                .ParseExact(csvDate, csvDateFormatters[nSeparators], null)
                .ToString("yyyy-MM-dd");
        }

        private static string[] GetLine(StreamReader reader)
        {
            var line = reader.ReadLine().Split(",");
            line = line.Select(c => c.Replace("\"", string.Empty).Trim()).ToArray();
            return line;
        }
    }
}
