using CommonServiceLocator;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Sample.Module1.Views;

namespace Prism.Sample.Module1
{
    public class Module1Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}