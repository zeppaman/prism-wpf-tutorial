using CommonServiceLocator;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Sample.Module2.Views;

namespace Prism.Sample.Module2
{
    public class Module2Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RegisterViewWithRegion("HeaderRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}