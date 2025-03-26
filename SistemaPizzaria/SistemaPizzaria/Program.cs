using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaPizzaria.Aplicacao.Servicos;
using SistemaPizzaria.Dominio.Servicos;
using SistemaPizzaria.Infraestrutura.Database;
using SistemaPizzaria.Infraestrutura.Repositorios;

namespace SistemaPizzaria
{
    internal static class Program
    {
 
        [STAThread]
        static void Main()
        {

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=estoque.db"));

            services.AddScoped<IPizzaDominioServico, PizzaDominioServico>();

            services.AddScoped<IPizzaRepositorio, PizzaRepositorio>();
            services.AddScoped<IPizzaAppServico, PizzaAppServico>();

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(mainForm: new Form1(serviceProvider));
        }
    }
}