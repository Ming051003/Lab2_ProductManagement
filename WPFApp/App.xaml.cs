using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; set; }
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigServices(IServiceCollection services)
        {
            //Register Services here
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IProductService, ProductService>();

            //Register Repository here
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();

            //Register Dbcontext
            services.AddDbContext<MyStoreContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            //Register Window
            services.AddTransient<LoginWindow>();
        }
    }

}
