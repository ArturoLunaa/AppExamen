using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppGasolinerasExamen.Data
{
    public static class Constants
    {
        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite |
                                                    SQLite.SQLiteOpenFlags.Create |
                                                    SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                //Formamos la ruta completa donde se guardará el archivo SQLite
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "AppGasolinerasExamen.db3");
            }
        }
    }
}
