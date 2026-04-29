using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace MobileStore.Pages.Mobile
{
    public class Create : PageModel
    {
        private const string ConnStr = "Server=localhost;Port=3306;Database=mobilestore;Uid=root;Pwd=root;";

        [BindProperty, Required(ErrorMessage = "Enter the brand")]
        public string Brand { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "Enter the model name")]
        public string Model { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "Enter the price")]
        [Range(1, 10000000, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [BindProperty, Required(ErrorMessage = "Select the focus")]
        public string Focus { get; set; } = "";

        [BindProperty, Required]
        [Range(1, 64, ErrorMessage = "RAM must be between 1 and 64 GB")]
        public int RamGb { get; set; } = 4;

        [BindProperty, Required]
        [Range(16, 2048, ErrorMessage = "Storage must be between 16 and 2048 GB")]
        public int StorageGb { get; set; } = 64;

        public string ErrorMessage { get; private set; } = "";

        public void OnPost()
        {
            if (!ModelState.IsValid) return;

            try
            {
                using var connection = new MySqlConnection(ConnStr);
                connection.Open();
                var cmd = new MySqlCommand(
                    "INSERT INTO Mobile (brand, model, price, focus, ram_gb, storage_gb) VALUES (@brand, @model, @price, @focus, @ram, @storage)",
                    connection);
                cmd.Parameters.AddWithValue("@brand",   Brand);
                cmd.Parameters.AddWithValue("@model",   Model);
                cmd.Parameters.AddWithValue("@price",   Price);
                cmd.Parameters.AddWithValue("@focus",   Focus);
                cmd.Parameters.AddWithValue("@ram",     RamGb);
                cmd.Parameters.AddWithValue("@storage", StorageGb);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            Response.Redirect("/mobile/Index");
        }
    }
}
