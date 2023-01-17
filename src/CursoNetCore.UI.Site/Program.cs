using CursoNetCore.UI.Site.Data;
using CursoNetCore.UI.Site.Servicos;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

using static CursoNetCore.UI.Site.Data.PedidoRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");    
});

builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDbContext")));

builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddTransient<IOperacaoTransient, Operacao>();
builder.Services.AddScoped<IOperacaoScoped, Operacao>();
builder.Services.AddSingleton<IOperacaoSingleton, Operacao>();
builder.Services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //carregar arquivos css e státicos

//app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Rota de área genérica (não necessário no caso da demo)
//app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Rota de áreas especializadas
app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");


//app.UseAuthorization();

//app.MapRazorPages();

app.Run();
