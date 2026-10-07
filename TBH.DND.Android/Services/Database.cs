using System;
using System.Collections.Generic;
using System.Text;

namespace TBH.DND.Android.Services
{
    public class Database
    {
        private readonly string dbPath;

        public bool SeedRequired { get; private set; } = false;

        public Database()
        {
            var folder = FileSystem.AppDataDirectory;
            dbPath = Path.Combine(folder, "character.db");
            SeedRequired = !File.Exists(dbPath);
        }

        public string DbPath => dbPath;
    }
}
