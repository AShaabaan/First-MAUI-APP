using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class NoteView : ContentView
{
    private readonly NoteViewModel noteView;

    public NoteView(NoteViewModel noteView)
	{
		InitializeComponent();
		BindingContext = noteView;
        this.noteView = noteView;
    }

    private void NoteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //set data to Entry and Editor 
        noteView.SetData();
    }
}