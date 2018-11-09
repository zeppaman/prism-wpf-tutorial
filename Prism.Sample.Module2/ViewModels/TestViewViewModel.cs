using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism.Sample.Module2.ViewModels
{
    public class TestViewViewModel : BindableBase
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        
        public TestViewViewModel()
        {
            Name = "Module2";
        }
    }
}
