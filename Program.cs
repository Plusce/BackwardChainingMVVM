using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackwardChainingMVVM.Model;
using BackwardChainingMVVM.Services;
using BackwardChainingMVVM.ViewModel;

namespace BackwardChainingMVVM
{
    static class Program
    {
        private static IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            builder.RegisterType<BackwardChainingTemperamentService>().As<IBackwardChainingTemperamentService>();
            builder.RegisterType<TemperamentViewModel>().As<ITemperamentViewModel>();
            builder.RegisterType<UserTemperament>().As<UserTemperament>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var viewModel = scope.Resolve<TemperamentViewModel>();
                Application.Run(new TemperamentView(viewModel));
            }
        }
    }
}
