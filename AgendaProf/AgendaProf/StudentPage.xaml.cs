using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaProf.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaProf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        NoteList sl;
        public StudentPage(NoteList slist)
        {
            InitializeComponent();
            sl = slist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var student = (Student)BindingContext;
            await App.Database.SaveStudentAsync(student);
            listView.ItemsSource = await App.Database.GetStudentsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var student = (Student)BindingContext;
            await App.Database.DeleteStudentAsync(student);
            listView.ItemsSource = await App.Database.GetStudentsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetStudentsAsync();
        }


    }
}