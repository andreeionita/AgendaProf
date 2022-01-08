using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaProf.Models;
using AgendaProf.Data;
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

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Student;
                var lp = new ListStudent()
                {
                    NoteListID = sl.ID,
                    StudentID = p.ID
                };
                await App.Database.SaveListStudentAsync(lp);
                p.ListStudents = new List<ListStudent> { lp };
                await Navigation.PopAsync();
            }

        }
    }
}