using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendaProf.Models;

namespace AgendaProf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (NoteList)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveNoteListAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (NoteList)BindingContext;
            await App.Database.DeleteNoteListAsync(slist);
            await Navigation.PopAsync();
        }

    }
}