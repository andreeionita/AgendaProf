using System;
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
            _database.CreateTableAsync<Student>().Wait();
            _database.CreateTableAsync<ListStudent>().Wait();

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
        public Task<int> SaveStudentAsync(Student product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteStudentAsync(Student product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return _database.Table<Student>().ToListAsync();
        }
        public Task<int> SaveListStudentAsync(ListStudent listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Student>> GetListStudentsAsync(int shoplistid)
        {
            return _database.QueryAsync<Student>(
            "select P.ID, P.Description from Student P"
            + " inner join ListStudent LP"
            + " on P.ID = LP.StudentID where LP.NoteListID = ?",
            shoplistid);
        }

    }
}
