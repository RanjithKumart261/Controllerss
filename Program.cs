using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Solution;
using System.Linq;

var session = Helper.OpenSession("User Id=postgres;Password=TRIVENI@1;Host=localhost;Database=Solution1");




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddControllers().AddNewtonsoftJson(opt => 
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    opt.SerializerSettings.MaxDepth = 4;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();

/*

session.Save(new User
{
    Email= "Ranjithkumar T",
    Password="TRIVENI@1"
}) ;
session.Flush();
session.Close();

var user = session.Query<User>().ToList();


 session.Update(user);
session.Flush();

var userRepository = new UserRepository(session);
var employeeRepository = new EmployeeRepository(session);


var user = session.Get<User>(8);
user.Email = "Ranjithkumar T";
var UpdateUser = userRepository.Get(8);
userRepository.Update(UpdateUser);


*/