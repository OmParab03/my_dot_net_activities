using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace dotnet.Pages.customer
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<CustomerInfo> listCustomers { get; set; } = [];
        public void OnGet()
        {

            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=root;"))
                {
                    connection.Open();
                    var command = new MySqlCommand("SELECT * FROM customer",connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCustomers.Add(new CustomerInfo
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                        
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving customers: {ex.Message}");
            }

        }


    }

    public class CustomerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }



    }

}