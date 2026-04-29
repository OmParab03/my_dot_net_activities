using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace MobileStore.Pages.Mobile
{
    public class Edit : PageModel
    {
        private const string ConnStr = "Server=localhost;Port=3306;Database=mobilestore;Uid=root;Pwd=root;";

        [BindProperty] public int Id { get; set; }
        [BindProperty, Required] public string Brand { get; set; } = "";
        [BindProperty, Required] public string Model { get; set; } = "";
        [BindProperty, Required, Range(1, 10000000)] public decimal Price { get; set; }
        [BindProperty, Required] public string Focus { get; set; } = "";
        [BindProperty, Required, Range(1, 64)] public int RamGb { get; set; }
        [BindProperty, Required, Range(16, 2048)] public int StorageGb { get; set; }

        public void OnGet(int id)
        {
            Id = id;
            using var connection = new MySqlConnection(ConnStr);
            connection.Open();
            var cmd = new MySqlCommand("SELECT * FROM Mobile WHERE id=@id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Brand     = reader.GetString("brand");
                Model     = reader.GetString("model");
                Price     = reader.GetDecimal("price");
                Focus     = reader.GetString("focus");
                RamGb     = reader.GetInt32("ram_gb");
                StorageGb = reader.GetInt32("storage_gb");
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid) return;
            using var connection = new MySqlConnection(ConnStr);
            connection.Open();
            var cmd = new MySqlCommand(
                "UPDATE Mobile SET brand=@brand, model=@model, price=@price, focus=@focus, ram_gb=@ram, storage_gb=@storage WHERE id=@id",
                connection);
            cmd.Parameters.AddWithValue("@brand",   Brand);
            cmd.Parameters.AddWithValue("@model",   Model);
            cmd.Parameters.AddWithValue("@price",   Price);
            cmd.Parameters.AddWithValue("@focus",   Focus);
            cmd.Parameters.AddWithValue("@ram",     RamGb);
            cmd.Parameters.AddWithValue("@storage", StorageGb);
            cmd.Parameters.AddWithValue("@id",      Id);
            cmd.ExecuteNonQuery();
            Response.Redirect("/mobile/Index");
        }
    }
}
