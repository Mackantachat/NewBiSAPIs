using Microsoft.AspNetCore.Authentication.Cookies;
using NewBiSAPIs.Model;
using System.Configuration;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddCors(options =>
{
    //ระบุโดเมน
    options.AddPolicy("AllowSpecificOrigins",
     builder =>
     {
         builder.WithOrigins(
             "http://example.com",
             "http://localhost:4200")
             .AllowAnyHeader()
             .AllowAnyMethod();
     });
    //เปิดเข้าถึงได้ทุกโดเมน
    options.AddPolicy("AllowAll",
     builder =>
     {
         builder.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod();
     });

});

var cultureInfo = new CultureInfo("th-TH");

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseCors(
   options => options.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod()
);

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//});

app.Run();
