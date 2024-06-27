using MauiApp1.ViewModels;
using MauiApp1.Views;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Container.Content = new NoteView(new NoteViewModel());
        }

    }

}
