using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Data;

namespace MauiApp1.ViewModels
{
    public partial class NoteViewModel :ObservableObject //: INotifyPropertyChanged
    {
        MyContext db;

        [ObservableProperty]
        private string noteTitle;

        [ObservableProperty]
        private string noteDescription;
        
        [ObservableProperty]
        private Note selectedNote;
        
        [ObservableProperty]
        ObservableCollection<Note> noteCollection;
        
        
        #region Old Commands
        //public ICommand AddNoteCommand { get; set; }
        //public ICommand RemoveNoteCommand { get; set; }
        //public ICommand EditNoteCommand { get; set; }
        #endregion
        public NoteViewModel() 
        {
            noteCollection = new ObservableCollection<Note>();
            db = new MyContext();

            //to check if data saved into db or not 
            var ListOfNotes = db.Notes.ToList();

            #region Old Methods for Commands
            //AddNoteCommand = new Command(AddNote);
            //RemoveNoteCommand = new Command(DeleteNote);
            //EditNoteCommand = new Command(EditNote);
            #endregion
        }


        [RelayCommand] //Auto Generate For Command >> EditNoteCommand 
        private void EditNote()
        {
            if (SelectedNote != null) 
            {
                foreach (Note note in NoteCollection.ToList()) 
                {
                    if(note ==  SelectedNote)
                    {
                         var newNote = new Note()
                         {
                             Id = note.Id,
                             Title = NoteTitle,
                             Description = NoteDescription,

                         };
                        NoteCollection.Remove(note);
                        NoteCollection.Add(newNote);

                    }
                }
            }
        }
        [RelayCommand]
        private void DeleteNote()
        {
            if(SelectedNote != null)
            {
                NoteCollection.Remove(SelectedNote);
                //Reset Values 
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }
        [RelayCommand]
        private void AddNote()
        {
            var newId = NoteCollection.Count > 0 ? NoteCollection.Max(p=> p.Id) +1 : 1;
            var note = new Note()
            {
                Id = newId,
                Title = NoteTitle,
                Description = NoteDescription,
             
            }; 

            //for test
            var note1 = new Note()
            {
                Title = NoteTitle,
                Description = NoteDescription,
             
            };
            if (note1 != null)
            {
                db.Notes.Add(note1);
                db.SaveChanges();
            }
            NoteCollection.Add(note);
            
            //Reset Values 
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
        }

        public void SetData()
        {
            NoteTitle = selectedNote.Title;
            NoteDescription = selectedNote.Description;
        }










        #region Old Way
        //public string NoteTitle
        //{
        //    get { return _noteTitle; }
        //    set 
        //    {
        //        if (_noteTitle != value)
        //        {
        //            _noteTitle = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public string NoteDescription
        //{
        //    get { return _noteDescription; }
        //    set 
        //    {
        //        if (_noteDescription != value)
        //        {
        //            _noteDescription = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public Note SelectedNote
        //{
        //    get { return _selectedNote; }
        //    set
        //    {
        //        if (_selectedNote != value)
        //        {
        //            _selectedNote = value;
        //            NoteTitle=_selectedNote.Title;   NoteDescription=_selectedNote.Description;
        //            OnPropertyChanged();
        //        }
        //    }

        //}
        #endregion

        #region Property Change From INotfy
        //public event PropertyChangedEventHandler? PropertyChanged;
        //protected void OnPropertyChanged ([CallerMemberName]string propertyName=null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion

    }
}
