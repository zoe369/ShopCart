using ShoppingCart_ASP.NET_MVC5.Dao;
using ShoppingCart_ASP.NET_MVC5.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ShoppingCart_ASP.NET_MVC5.Controllers
{
    [SessionExpire]
    public class SearchController : Controller
    {

        public ActionResult Partial(string search)

        {
            if (search == "")
            {
                ViewBag.a = "Please enter a search item in the search box..";
            }
            List<CarModel> car = new List<CarModel>();
            using (SqlConnection conn = new SqlConnection("Server=.; Database=Sasha; Integrated Security=true"))
            {
                conn.Open();
                string sql = @"select * from Car where Model like '%" + search + "%'";
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
                }
            }
            if (car != null)
            {
                ViewData["partial"] = car;
            }
            else
                ViewBag.alert = "Sorry, the item is out of stock..";
            ViewBag.Count = int.Parse(Request.Cookies["Count"].Value);
            ViewBag.firstname = Request.Cookies["firstname"].Value;
            ViewBag.a = 2;
            return View("../Home/Home");
        }
    }
}