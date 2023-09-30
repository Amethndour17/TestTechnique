

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//utilisation du inmemory dans notre projet par contraint d'avoir le mssql local db
builder.Services.AddDbContext<DbContextTache>(option => option.UseInMemoryDatabase("TaskDb"));
builder.Services.AddScoped<IAdminRepository, AdminRepositoryService>();
builder.Services.AddScoped<ITaskRepository, TaskRepositorySerive>();
builder.Services.AddScoped<IProfesseurRepository, ProfesseurRepositoryService>();
builder.Services.AddScoped<IEleveRepository, EleveRepositoryService>();
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
