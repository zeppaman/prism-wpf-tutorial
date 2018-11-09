using Prism.Sample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Sample.Module1;
using System;
using Prism.Sample.Module2;

namespace Prism.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        IModuleCatalog catalog;
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            catalog = this.CreateModuleCatalog();
            containerRegistry.RegisterInstance<IModuleCatalog>(catalog);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type moduleCType = typeof(Module1Module);

           
            catalog.AddModule<Module1Module>(InitializationMode.WhenAvailable);
            catalog.AddModule<Module2Module>(InitializationMode.WhenAvailable);
        }
    }
}
