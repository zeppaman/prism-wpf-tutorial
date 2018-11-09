using Prism.Commands;
using Prism.Mvvm;

namespace Prism.Sample.Module1.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            Name = "TAB";
            TestCommand = new DelegateCommand<string>(x => { ExecuteTestCommand(x); });
        }

        private void ExecuteTestCommand(string x)
        {
            Message += "," + x;
        }

        public DelegateCommand<string> TestCommand { get; private set; }
    }
}