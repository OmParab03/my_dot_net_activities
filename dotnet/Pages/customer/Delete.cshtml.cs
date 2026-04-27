using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace dotnet.Pages.customer
{
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;

        public Delete(ILogger<Delete> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public int Id { get; set; }

        // GET: /customer/Delete/5
        public IActionResult OnGet(int id)
        {
            if (id <= 0)
            {
                return RedirectToPage("/customer/Index");
            }

            Id = id;
            return Page();
        }

        // POST: delete confirmed
        public IActionResult OnPost()
        {
            try
            {
                using var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=root;"
                );

                connection.Open();

                using var command = new MySqlCommand(
                    "DELETE FROM customer WHERE id = @id",
                    connection
                );

                command.Parameters.AddWithValue("@id", Id);

                int rows = command.ExecuteNonQuery();

                if (rows == 0)
                {
                    ModelState.AddModelError("", "Customer not found.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting customer");
                ModelState.AddModelError("", "An error occurred while deleting.");
                return Page();
            }

            return RedirectToPage("/customer/Index");
        }
    }
}