using AppUtn.Examen.Pages;

namespace AppUtn.Examen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }
    }
}
