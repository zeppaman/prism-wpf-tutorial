using Prism.Mvvm;

namespace Prism.Sample.Module2.ViewModels
{
    public class TestViewViewModel : BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public TestViewViewModel()
        {
            Name = "Module2";
        }
    }
}