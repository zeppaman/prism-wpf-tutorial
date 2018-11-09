using CommonServiceLocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Sample.Module2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Sample.Module2.ViewModels
{
    public class ViewAViewModel : BindableBase
    {

        public DelegateCommand AddNewItemCommand { get; private set; }
        public ViewAViewModel()
        {
            AddNewItemCommand = new DelegateCommand(() => {
                ExecuteAddNewItemCommand();
            });
        }

        private void ExecuteAddNewItemCommand()
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.AddToRegion("TabRegion", new TestView());
        }
    }
}
