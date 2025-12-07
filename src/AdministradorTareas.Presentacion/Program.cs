using AdministradorTareas.Dominio.Repositorios;
using AdministradorTareas.Dominio.Servicios;
using AdministradorTareas.Infraestructura.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace AdministradorTareas.Presentacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Contenedor de Servicios
            var services = new ServiceCollection();
            ConfigureServices(services);
            
            // Proveedor de Servicios 
            var serviceProvider = services.BuildServiceProvider();

            // Formulario principal de la aplicación
            var mainForm = serviceProvider.GetRequiredService<FrmPrincipal>(); 
            
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Registrar Servicios y Repositorios
            services.AddSingleton<ITareaRepositorio, TareaRepositorio>();
            services.AddSingleton<ITareaServicio, TareaServicio>();
            services.AddTransient<FrmPrincipal>();
            services.AddTransient<FrmEditorTarea>();
        }
    }
}