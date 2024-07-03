using DoToo.Views;

namespace DoToo
{
    public partial class App : Application
    {
        public App(MainView mainView)
        {
            InitializeComponent();
            MainPage = new NavigationPage(mainView);
        }
    }
}
