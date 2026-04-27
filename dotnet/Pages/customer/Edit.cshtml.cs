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
    public class Edit : PageModel
{
    [BindProperty]
    public int id { get; set; }

    [BindProperty, Required(ErrorMessage = "Enter the name")]
    public string name { get; set; } = "";

    [BindProperty, Required, EmailAddress]
    public string email { get; set; } = "";

    public void OnGet(int id)
    {
        this.id = id;

        using var connection = new MySqlConnection(
            "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=root;"
        );

        connection.Open();

        var cmd = new MySqlCommand(
            "SELECT name, email FROM customer WHERE id=@id",
            connection
        );
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            name = reader.GetString("name");
            email = reader.GetString("email");
        }
    }

    public void OnPost()
    {
        if (!ModelState.IsValid) return;

        using var connection = new MySqlConnection(
            "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=root;"
        );

        connection.Open();

        var cmd = new MySqlCommand(
            "UPDATE customer SET name=@name, email=@email WHERE id=@id",
            connection
        );

        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();

        Response.Redirect("/customer/Index");
    }
}
}