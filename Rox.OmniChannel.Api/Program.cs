using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rox.OmniChannel.CrossCutting.Enums;
using Rox.OmniChannel.Domain.Models;
using Rox.OmniChannel.Domain.Repository;
using Rox.OmniChannel.Infrastructure.Data;
using Rox.OmniChannel.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
// Aprenda mais sobre configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await CreateRoles(roleManager);
}


// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

async Task CreateRoles(RoleManager<IdentityRole> roleManager)
{
    string[] roleNames = { ERoles.Administrator,
                           ERoles.Customer, 
                           ERoles.TenantManager };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
            await roleManager.CreateAsync(new IdentityRole(roleName));
    }
}