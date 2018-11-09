# Prism Sample
This project is a tutorial for a quick prism project setup to show basic capabilities
- Modules
- Data Binding
- Region

## Tutorial
Steps:

1. install Prism Visual studio tools
2. Create a new Prism project
4. Create Module
5. Integrate modules
6. Configure Prism project 


## install Prism Visual studio tools
![](https://raw.githubusercontent.com/zeppaman/prism-wpf-tutorial/master/docs/2.install-plugin.png)
## Create a new Prism project
![](https://raw.githubusercontent.com/zeppaman/prism-wpf-tutorial/master/docs/0.add_blank_app.png)
![](https://raw.githubusercontent.com/zeppaman/prism-wpf-tutorial/master/docs/1.choose_di.png)
## Create Module
![](https://raw.githubusercontent.com/zeppaman/prism-wpf-tutorial/master/docs/4.addmodule.png)


## Configure Prism project 

### Register modules

Add project reference to the shell application. This can be also done using nuget on huge applications.

In `App.xaml.cs` add:

```cs
        IModuleCatalog catalog;        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //get a local module catalog (or create your own implementation and register)
            catalog = this.CreateModuleCatalog();
            containerRegistry.RegisterInstance<IModuleCatalog>(catalog);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type moduleCType = typeof(Module1Module);

            //Manually add here moduler, or use xml config, or directory loading
            catalog.AddModule<Module1Module>(InitializationMode.WhenAvailable);
            catalog.AddModule<Module2Module>(InitializationMode.WhenAvailable);
        }
```

### Add missing dependency on modules
![](https://raw.githubusercontent.com/zeppaman/prism-wpf-tutorial/master/docs/3.missingdependency.png)


### Register region from controls

Main windows act as wireframe, you can define many region:

```xml
  <DockPanel>
        <Border BorderBrush="Black"  BorderThickness="2" DockPanel.Dock="Top">
            <WrapPanel Orientation="Horizontal">
                <TextBlock Text="{Binding Title}" />
                <ContentControl prism:RegionManager.RegionName="HeaderRegion"/>
            </WrapPanel>
        </Border>
        <Border BorderBrush="Red" BorderThickness="2" DockPanel.Dock="Left" Width="300">
         <ContentControl prism:RegionManager.RegionName="ContentRegion" />
        </Border>
        <Border BorderBrush="Blue" BorderThickness="2" >
            <TabControl prism:RegionManager.RegionName="TabRegion"  >
                
            </TabControl>
        </Border>
    </DockPanel>
```

In  module file you can define where contols will be placed at runtime:

```cs
   public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RegisterViewWithRegion("HeaderRegion", typeof(ViewA));

        }
```
### Data binding

Define in view model the property. 
```cs
 private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
```

In xaml you simply need to bind to property
```xml
<TextBlock Text="{Binding Message}" />
```
### Add a command
In view model, you just need to define the delegate command.

```cs
    public ViewAViewModel()
    {
        this.TestCommand = new DelegateCommand<string>(x => { ExecuteTestCommand(x); });
    }

    private void ExecuteTestCommand(string x)
    {
        //DO Stuff here, x parameter is passed from Xaml
    }

    public DelegateCommand<string> TestCommand { get; private set; }
```

In xaml is called as usual:


```xml
 <Button Command="{Binding Path=TestCommand}" 
	 CommandParameter="{Binding ElementName='TextToAdd', Path='Text'}"   
	 Content="TEST!" />
```

### Add Controls dinamically into region
Components can be added at runtime simply using `regionmanager`


```cs
	var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
	regionManager.AddToRegion("TabRegion", new TestView());
```
