using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace AgendaProf.Models
{
    public class ListStudent
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(NoteList))]
        public int NoteListID { get; set; }
        public int StudentID { get; set; }

    }
}
