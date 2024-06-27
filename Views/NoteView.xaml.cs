using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class NoteView : ContentView
{
	public NoteView()
	{
		InitializeComponent();
		BindingContext = new NoteViewModel();
	}
}