using Prism.Ioc;
using Prism.Modularity;
using Prism.Sample.Module1;
using Prism.Sample.Module2;
using Prism.Sample.Views;
using System;
using System.Windows;

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

        private IModuleCatalog catalog;

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //get a local module catalog (or create your own implementation and register)
            catalog = CreateModuleCatalog();
            containerRegistry.RegisterInstance<IModuleCatalog>(catalog);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type moduleCType = typeof(Module1Module);

            //Manually add here moduler, or use xml config, or directory loading
            catalog.AddModule<Module1Module>(InitializationMode.WhenAvailable);
            catalog.AddModule<Module2Module>(InitializationMode.WhenAvailable);
        }
    }
}