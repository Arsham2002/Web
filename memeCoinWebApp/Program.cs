using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcUser.Data;
using MvcTransfer.Data;
using MvcFund.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcFundContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcFundContext") ?? throw new InvalidOperationException("Connection string 'MvcFundContext' not found.")));
builder.Services.AddDbContext<MvcTransferContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcTransferContext") ?? throw new InvalidOperationException("Connection string 'MvcTransferContext' not found.")));
builder.Services.AddDbContext<MvcUserContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcUserContext") ?? throw new InvalidOperationException("Connection string 'MvcUserContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
