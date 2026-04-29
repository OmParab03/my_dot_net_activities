using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace MobileStore.Pages.Mobile
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private const string ConnStr = "Server=localhost;Port=3306;Database=mobilestore;Uid=root;Pwd=root;";

        public Index(ILogger<Index> logger) => _logger = logger;

        public List<MobileInfo> Mobiles { get; set; } = new();

        public void OnGet()
        {
            try
            {
                using var connection = new MySqlConnection(ConnStr);
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Mobile ORDER BY id DESC", connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mobiles.Add(new MobileInfo
                    {
                        Id        = reader.GetInt32("id"),
                        Brand     = reader.GetString("brand"),
                        Model     = reader.GetString("model"),
                        Price     = reader.GetDecimal("price"),
                        Focus     = reader.GetString("focus"),
                        RamGb     = reader.GetInt32("ram_gb"),
                        StorageGb = reader.GetInt32("storage_gb"),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching mobiles: {msg}", ex.Message);
            }
        }
    }

    public class MobileInfo
    {
        public int     Id        { get; set; }
        public string  Brand     { get; set; } = "";
        public string  Model     { get; set; } = "";
        public decimal Price     { get; set; }
        public string  Focus     { get; set; } = "";
        public int     RamGb     { get; set; }
        public int     StorageGb { get; set; }
    }
}
