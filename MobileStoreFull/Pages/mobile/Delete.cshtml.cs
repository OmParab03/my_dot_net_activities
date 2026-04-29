using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace MobileStore.Pages.Mobile
{
    public class Delete : PageModel
    {
        private const string ConnStr = "Server=localhost;Port=3306;Database=mobilestore;Uid=root;Pwd=root;";

        [BindProperty] public int    Id    { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";

        public void OnGet(int id)
        {
            Id = id;
            using var connection = new MySqlConnection(ConnStr);
            connection.Open();
            var cmd = new MySqlCommand("SELECT brand, model FROM Mobile WHERE id=@id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Brand = reader.GetString("brand");
                Model = reader.GetString("model");
            }
        }

        public void OnPost()
        {
            using var connection = new MySqlConnection(ConnStr);
            connection.Open();
            var cmd = new MySqlCommand("DELETE FROM Mobile WHERE id=@id", connection);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.ExecuteNonQuery();
            Response.Redirect("/mobile/Index");
        }
    }
}
