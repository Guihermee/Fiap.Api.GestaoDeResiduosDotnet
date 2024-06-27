using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Fiap.Api.GestaoDeResiduos.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Oracle.ManagedDataAccess.Client; // Adicione esta linha

var builder = WebApplication.CreateBuilder(args);

#region Configuração do banco
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
	opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Mapper
// Add services to the container.
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
	c.AllowNullCollections = true;
	c.AllowNullDestinationValues = true;
	c.CreateMap<RotaModel, RotaViewModel>();
	c.CreateMap<RotaViewModel, RotaModel>();

	c.CreateMap<AterroModel, AterroViewModel>();
	c.CreateMap<AterroViewModel, AterroModel>();

	c.CreateMap<CaminhaoModel, CaminhaoViewModel>();
	c.CreateMap<CaminhaoViewModel, CaminhaoModel>();
}
);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region Repositorios
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Adicione esta linha
																		 // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRotaRepository, RotaRepository>();
builder.Services.AddScoped<IRotasService, RotasService>();

builder.Services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
builder.Services.AddScoped<ICaminhaoService, CaminhaoService>();

builder.Services.AddScoped<IAterroRepository, AterroRepository>();
builder.Services.AddScoped<IAterroService, AterroService>();

builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
