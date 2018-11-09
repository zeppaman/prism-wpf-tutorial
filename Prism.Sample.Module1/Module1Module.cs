using Prism.Sample.Module1.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using CommonServiceLocator;

namespace Prism.Sample.Module1
{
    public class Module1Module : IModule
    {
        
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
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