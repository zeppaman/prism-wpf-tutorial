using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Sample.Module1.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            Name = "TAB";
            this.TestCommand = new DelegateCommand<string>(x => { ExecuteTestCommand(x); });
        }

        private void ExecuteTestCommand(string x)
        {
            this.Message += "," + x;
        }

        public DelegateCommand<string> TestCommand { get; private set; }
    }
}
