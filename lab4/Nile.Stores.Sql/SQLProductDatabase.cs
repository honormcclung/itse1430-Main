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
            //Using statement
            // IDisposable
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

                //Execute command and get result
                object result = cmd.ExecuteScalar();
                product.Id = Convert.ToInt32(result);

                return product;
            };

            #region try-finally equivalent
            //SqlConnection conn = null;

            //try
            //{
            //    conn = OpenConnection();

            //    throw new NotImplementedException();
            //} finally
            //{
            //    //Clean up connection
            //    conn?.Close();
            //    conn?.Dispose();
            //};
            #endregion
        }
        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                //Create command 1 - using new
                var cmd = new SqlCommand("GetProducts", conn);

                //Need data adapter for Dataset
                var da = new SqlDataAdapter(cmd);

                //Buffered IO                
                da.Fill(ds);
            };

            //Data loaded, can work with it now
            // Find table and then enumerate rows to get data
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = (int)row[0],                   //Ordinal index with cast
                        Name = row["Name"] as string,      //Name with cast
                        Description = row.IsNull(2) ? "" : row.Field<string>(2), //Ordinal index with generic
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
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

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Product() {
                            Id = (int)reader[0],              //Ordinal with cast
                            Name = reader["Name"] as string, //Column name with cast
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),//Typed name with ordinal
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
                //Create command option 3 - generic
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteProduct";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //Set parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Execute command 2 - no results/don't care
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

                //Execute command and get result
                cmd.ExecuteNonQuery();

                #region SQL Injection

                //movie.Title = "SELECT * FROM Movies WHERE Name = '';DELETE FROM Movies;SELECT * FROM MOvies WHERE Name = ''";
                //var cmd2 = new SqlCommand($"SELECT * FROM Movies WHERE Name = @title");
                //cmd2.Parameters.AddWithValue("@title", movie.Title); 

                #endregion
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