using ClientUpd8.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ClientContext>();
builder.Services.AddScoped<IClientContext, ClientContext>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseBrowserLink();
}

app.UseHttpsRedirection();

// app.UseEndpoints(endpoints =>
// {
//   endpoints.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}"
//   );
// });

app.UseAuthorization();

app.MapControllers();

app.Run();
