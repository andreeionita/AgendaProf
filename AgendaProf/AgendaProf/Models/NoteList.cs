using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace AgendaProf.Models
{
    public class NoteList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
