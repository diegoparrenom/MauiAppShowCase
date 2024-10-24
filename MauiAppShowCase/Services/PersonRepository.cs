using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppShowCase.Services
{
    public class PersonRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Person>();
        }
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;

        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid Name required");

                Person person = new() {Name = name};
                result = conn.Insert(person);

                StatusMessage = string.Format("{0} records added (Name: {1}", result, name);
            }
            catch(Exception ex) {
            
                StatusMessage = string.Format("Failed to add {0} .Error: {1}", name, ex.Message);
            }
        }
        public List<Person> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}",ex.Message);
            }
            return new List<Person>();
        }
    }
}
