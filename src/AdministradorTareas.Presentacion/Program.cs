using AdministradorTareas.Dominio.Servicios;
using AdministradorTareas.Dominio.Repositorios;
using AdministradorTareas.Infraestructura.Repositorios;
using AdministradorTareas.Infraestructura.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace AdministradorTareas.Presentacion;

static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            services.AddScoped<ITareaRepositorio, TareaRepositorio>();
            services.AddScoped<ITareaServicio, TareaServicio>();
            services.AddScoped<FrmPrincipal>();
            //services.AddScoped<FrmEditorTarea>();

            var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<FrmPrincipal>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Startup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}