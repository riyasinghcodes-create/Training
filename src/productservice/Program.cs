using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using productservice.data;


var builder = WebApplication.CreateBuilder(args);
// Key Vault se configuration add karo
builder.Configuration.AddAzureKeyVault(
    new Uri("https://productservice-kv.vault.azure.net/"),
    new DefaultAzureCredential());


builder.Services.AddControllers();
//builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ProductDbConnectionString"]));  //secret key name
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();