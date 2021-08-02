using ShoppingCart_ASP.NET_MVC5.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ShoppingCart_ASP.NET_MVC5.Dao
{
    public class ProductDetails
    {
        public static List<CarModel> Callme()
        {
            List<CarModel> car = new List<CarModel>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=Sasha; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT * from Car";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CarModel c = new CarModel()
                    {
                        Car_id = (int)reader["ID"],
                        Car_marca = (string)reader["Marca"],
                        Car_model = (string)reader["Model"],
                        Car_price = (int)reader["Pret"],
                        Car_image = (string)reader["Image"],
                        Car_an = (int)reader["An fabricatie"],
                        Car_km = (int)reader["Km"],
                        Car_culoare = (string)reader["Culoare"],
                        Car_cutie = (string)reader["Cutie"]
                    };
                    car.Add(c);
                    Debug.WriteLine(c.Car_id);
                }
            }
            return car;
        }
    }
}