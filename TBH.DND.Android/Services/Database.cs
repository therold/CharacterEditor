using System;
using System.Collections.Generic;
using System.Text;

namespace TBH.DND.Android.Services
{
    public class Database
    {
        private readonly string dbPath;

        public Database()
        {
            var folder = FileSystem.AppDataDirectory;
            dbPath = Path.Combine(folder, "character.db");
        }

        public string DbPath => dbPath;
    }
}
