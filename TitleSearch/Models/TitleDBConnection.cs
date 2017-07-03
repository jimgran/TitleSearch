using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TitleSearch.Models
{
    public class TitlesDBConnection
    {
        private const string CONNECTION = "Server=LINK\\SQLEXPRESS; Database=Titles; Trusted_Connection=true;";

        public IEnumerable<string> searchForTitles(IEnumerable<string> terms)
        {
            string sql = "SELECT TitleName FROM dbo.Title WHERE ";
            sql += String.Join(" OR ", terms.Select(term => string.Format("TitleName LIKE \'%{0}%\'", term)));
            return executeSql(sql);
        }

        private IEnumerable<string> executeSql(string sql)
        {
            var content = new List<string>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = CONNECTION;
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            content.Add(reader[0].ToString());
                        }
                    }
                }
            }

            return content;
        }

    }
}
