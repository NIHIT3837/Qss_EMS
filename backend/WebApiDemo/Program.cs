using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using WebApiDemo.Models;
using WebAppiDemo.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.`

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();

//ADD CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  // Allowed origin
              .AllowAnyHeader()                    // Allow any headers
              .AllowAnyMethod();                    // Allow any method (GET, POST, etc.)
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



//var employees = new List<Employee>
//{
//    new Employee { Id = 1, Name = "John Doe", Position = "Developer", Salary = 60000 },
//    new Employee { Id = 2, Name = "Jane Smith", Position = "Manager", Salary = 80000 }
//};




//// Get all employees
//app.MapGet("/employees", () => employees);

//// Get a single employee by ID
//app.MapGet("/employees/{id:int}", (int id) =>
//{
//    var employee = employees.FirstOrDefault(e => e.Id == id);
//    return employee is not null ? Results.Ok(employee) : Results.NotFound("Employee not found.");
//});

//// Add a new employee
//app.MapPost("/employees", (Employee employee) =>
//{
//    employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
//    employees.Add(employee);
//    return Results.Created($"/employees/{employee.Id}", employee);
//});

//// Update an existing employee
//app.MapPut("/employees/{id:int}", (int id, Employee updatedEmployee) =>
//{
//    var employee = employees.FirstOrDefault(e => e.Id == id);
//    if (employee is null)
//    {
//        return Results.NotFound("Employee not found.");
//    }

//    employee.Name = updatedEmployee.Name;
//    employee.Position = updatedEmployee.Position;
//    employee.Salary = updatedEmployee.Salary;
//    return Results.Ok(employee);
//});

//// Delete an employee
//app.MapDelete("/employees/{id:int}", (int id) =>
//{
//    var employee = employees.FirstOrDefault(e => e.Id == id);
//    if (employee is null)
//    {
//        return Results.NotFound("Employee not found.");
//    }

//    employees.Remove(employee);
//    return Results.Ok($"Employee with ID {id} deleted.");
//});
app.UseCors("AllowLocalhost");
app.MapControllers();


app.Run();

