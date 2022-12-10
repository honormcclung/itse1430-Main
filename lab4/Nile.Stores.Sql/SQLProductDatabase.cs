/*
 * Honor McClung
 * Lab 4
 * ISTE 1430 - Fall 2022 
 * 12/9/2022
 */

using System.Data;
using System.Data.SqlClient;

namespace Nile.Stores.Sql
{
    public class SQLProductDatabase : ProductDatabase
    {
        public SQLProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                //Create command option 2 - long way
                var cmd = new SqlCommand();
                cmd.CommandText = "AddMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure; //CommandType.Text;

                //Add parameters option 1 - best way
                cmd.Parameters.AddWithValue("@name", product.Name);

                //Add parameters option 2 - long way (or with type)
                var paramRating = new SqlParameter("@price", product.Price);
                cmd.Parameters.Add(paramRating);

                //Add parameters option 3 - generic
                var paramDescription = cmd.CreateParameter();
                paramDescription.ParameterName = "@description";
                paramDescription.Value = product.Description;
                paramDescription.DbType = DbType.String;
                cmd.Parameters.Add(paramDescription);

                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                object result = cmd.ExecuteScalar();
                product.Id = Convert.ToInt32(result);

                return product;
            };
        }
        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProducts", conn);

                var da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = (int)row[0],                  
                        Name = row["Name"] as string,      
                        Description = row.IsNull(2) ? "" : row.Field<string>(2),                         IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                    };
                };
            };
        }
        protected override Product GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Product() {
                            Id = (int)reader[0],              
                            Name = reader["Name"] as string, 
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            IsDiscontinued = reader.GetFieldValue<bool>("IsDiscontinued")
                        };
                    };
                };
            };

            return null;
        }
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteProduct";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            };
        }
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "UpdateProdcut";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure; //CommandType.Text;

                cmd.Parameters.AddWithValue("@id", newItem.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@isClassic", newItem.IsDiscontinued);

                cmd.ExecuteNonQuery();
            };

            return newItem;
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}