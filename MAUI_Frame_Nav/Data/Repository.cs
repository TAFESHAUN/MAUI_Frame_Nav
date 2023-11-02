using System.Text;
using System.Configuration;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

//using System.Linq;

namespace MAUI_Frame_Nav.Data
{
    /// <summary>
    /// Repoistory for database connection -> Updates/Deletes/Inserts of New products
    /// Could use a reset DB feature
    /// CRUD FEATURES
    /// </summary>
    public class Repository
    {
        #region Connection String
        private string _connectionString;
        public Repository()
        {
            _connectionString = @"Data Source=DESKTOP-TBL2MHJ;Initial Catalog=StoreDB;Integrated Security=True;Trust Server Certificate=True";
            //_connectionString = ConfigurationManager.ConnectionStrings["ShopConnect"].ConnectionString;
            //_connectionString = ConfigurationManager.OpenMachineConfiguration <- default directories, browser options, win11 account -> PIN, Gesture, Facial Reg etc.
        }
        #endregion

        #region Get Product
        public IEnumerable<Products> GetProduct()
        {
            var productList = new List<Products>();
            //OPEN THE DB
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Products", connection)) //COMMAND THE DB TO DO SOMETHING
            {
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var aProduct = new Products
                        {
                            Id = reader.GetInt32(0),
                            Product = reader.GetString(1),
                            Price = Convert.ToDouble(reader.GetDecimal(2)),
                            Code = reader.GetString(3).ToUpper()
                        };
                        productList.Add(aProduct);

                    }
                }
            }
            return productList;
        }
        #endregion

        #region Update Product
        public int UpdateProduct(Products p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "UPDATE Products SET Product=@Product,Price=@Price,Code=@Code WHERE Id = @id";
                command.Parameters.AddWithValue("@id", p.Id);
                command.Parameters.AddWithValue("@Product", p.Product);
                command.Parameters.AddWithValue("@Price", p.Price);
                command.Parameters.AddWithValue("@Code", p.Code);

                command.Connection = connection;
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

        #region Insert Product
        public int InsertProduct(Products p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "INSERT INTO Products VALUES (@Product,@Price,@Code)";
                //command.Parameters.AddWithValue("@id", p.Id);
                command.Parameters.AddWithValue("@Product", p.Product);
                command.Parameters.AddWithValue("@Price", p.Price);
                command.Parameters.AddWithValue("@Code", p.Code);
                command.Connection = connection;
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

        #region Delete Product
        public int DeleteProduct(Products p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "DELETE FROM Products WHERE Id=@id";
                command.Parameters.AddWithValue("@id", p.Id);
                command.Connection = connection;
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion
    }
}
