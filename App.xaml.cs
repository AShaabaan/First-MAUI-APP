using MauiApp1.ViewModels;
using MauiApp1.Views;
using SQLitePCL;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Batteries.Init();


        }
    }
}
