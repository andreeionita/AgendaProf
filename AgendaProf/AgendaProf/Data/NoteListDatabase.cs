﻿using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using AgendaProf.Models;

namespace AgendaProf.Data
{
    public class NoteListDatabase
    {

        readonly SQLiteAsyncConnection _database;
        public NoteListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NoteList>().Wait();
        }
        public Task<List<NoteList>> GetNoteListsAsync()
        {
            return _database.Table<NoteList>().ToListAsync();
        }
        public Task<NoteList> GetNoteListAsync(int id)
        {
            return _database.Table<NoteList>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteListAsync(NoteList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteNoteListAsync(NoteList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}