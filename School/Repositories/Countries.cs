using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public class Countries : Repository
    {
        public static Country RetrieveRandomOne()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var sqlCommand = new SqlCommand("RetrieveRandomCountry", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();
                    //SqlParameter custId = cmd.Parameters.AddWithValue("@CustomerId", 10);
                    Country country = null;
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            country = new Country
                            {
                                Code = sqlDataReader["Code"].ToString(),
                                Name = sqlDataReader["Name"].ToString()
                            };
                        }
                    }
                    //return (Guid) sqlCommand.ExecuteScalar();
                    return country;
                }
            }
        }
    }
}