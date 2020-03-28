using System;
using System.Collections.Generic;
using System.Data;
using lunchbox.api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace lunchbox.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private MySqlConnection con;
        string conStr;

        public MasterDataController(IConfiguration config)
        {
            conStr = config.GetConnectionString("DefaultConnection");
        }

        // GET api/values
        [HttpGet]
        [Route("items")]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from item", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.id = reader.GetInt16("id");
                            item.price = reader.GetDouble("price");
                            item.description = reader.GetString("description");
                            item.image = reader.GetString("image");
                            item.ingradients = reader.GetString("ingradients");
                            item.name = reader.GetString("name");
                            item.nutrients = reader.GetString("nutrients");
                            item.weight = reader.GetString("weight");
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }


        [HttpGet]
        [Route("menu_item")]
        public ActionResult<IEnumerable<MenuItem>> GetMenuItemMapping()
        {
            List<MenuItem> items = new List<MenuItem>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from menu_item", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            MenuItem item = new MenuItem();
                            item.item_id = reader.GetInt16("item_id");
                            item.menu_id = reader.GetInt16("menu_id");
                            item.quantity = reader.GetInt16("quantity");
                            
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }

        [HttpGet]
        [Route("menu_type")]
        public ActionResult<IEnumerable<MenuType>> GetMenuTypes()
        {
            var items = new List<MenuType>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from menu_type", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new MenuType();
                            item.id = reader.GetInt16("id");
                            item.type = reader.GetString("type");

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }

        [HttpGet]
        [Route("meal_type")]
        public ActionResult<IEnumerable<MealType>> GetMealTypes()
        {
            var items = new List<MealType>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from meal_type", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new MealType();
                            item.id = reader.GetInt16("id");
                            item.type = reader.GetString("type");

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }


        [HttpGet]
        [Route("weekly_menu")]
        public ActionResult<IEnumerable<WeeklyMenu>> GetWeeklyMenu()
        {
            var items = new List<WeeklyMenu>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from weekly_menu", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new WeeklyMenu();
                            item.id = reader.GetInt16("id");
                            item.day = reader.GetString("type");
                            item.menu_id = reader.GetInt16("menu_id");
                            item.meal_type_id = reader.GetInt16("meal_type_id");

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }

        [HttpGet]
        [Route("plan")]
        public ActionResult<IEnumerable<Plan>> GetPlans()
        {
            var items = new List<Plan>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from plan", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new Plan();
                            item.id = reader.GetInt16("id");
                            item.description = reader.GetString("description");
                            item.duration_id = reader.GetInt16("duration_id");
                            item.meal_type_id = reader.GetInt16("meal_type_id");
                            item.price = reader.GetDouble("price");
                            item.name = reader.GetString("name"); 

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }

        [HttpGet]
        [Route("plan_duration")]
        public ActionResult<IEnumerable<PlanDuration>> GetPlanDurations()
        {
            var items = new List<PlanDuration>();
            try
            {
                using (con = new MySqlConnection(conStr))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from plan_duration", con);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new PlanDuration();
                            item.id = reader.GetInt16("id");
                            item.duration = reader.GetString("duration");

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("{id}")]
        public ActionResult<string> Test(int id)
        {
            return id.ToString();
        }

    }
}
