using Caso_Di_Studio.Data;
using Caso_Di_Studio.Repository;
using Caso_Di_Studio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 
 
builder.Services.AddCors(options => 
{ 
    options.AddPolicy(name: MyAllowSpecificOrigins, 
                      policy => 
                      { 
                          policy.WithOrigins("http://localhost:5500")
                                .AllowAnyHeader()
                                .AllowAnyMethod(); 
                      }); 
}); 

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IPublishingHRepository, PublishingHRepository>();
builder.Services.AddScoped<IPublishingHService, PublishingHService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);  // Applica la politica CORS
app.UseAuthorization();
app.MapControllers();
app.Run();
