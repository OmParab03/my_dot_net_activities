var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// ADD THIS
builder.Services.AddSession(options =>
{
    
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// ADD THIS (before MapRazorPages)
app.UseSession();

app.MapRazorPages();
app.Run();