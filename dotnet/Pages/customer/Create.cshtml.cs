using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace dotnet.Pages.customer
{
    public class Create : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Enter the name")]
        public string name { get; set; } = "";
        [BindProperty, Required(ErrorMessage = "Enter the email"),
        EmailAddress(ErrorMessage = "Invalid email format")]
        public string email { get; set; } = "";
        public string ErrorMessage { get; private set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Form is Invalid");
                return;
            }
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=root;"
                ))
                {
                    connection.Open();
                    var command = new MySqlCommand("INSERT INTO Customer (name,email) VALUES(@CustName, @CustEmail)", connection);
                    command.Parameters.AddWithValue("@CustName", name);
                    command.Parameters.AddWithValue("@CustEmail", email);
                    
                    int i = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding customer." + $"Error:{ex.Message}"); ErrorMessage = ex.Message;
                return;
            }
            Response.Redirect("/customer/Index");
        }
    }

}