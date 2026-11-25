using Microsoft.Data.Sqlite;

namespace EscapeGameTC
{
    internal class DatabaseClass
    {
        public static SqliteConnection databaseConnection = new SqliteConnection("DataSource=DatabaseEvasionServeur.db");
        public static Random rand = new Random();

        public static void CreateDatabase()
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
            tableCmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Salle (
                ID INTEGER,
                Nom TEXT NOT NULL,
                PRIMARY KEY(ID AUTOINCREMENT),
                UNIQUE(Nom)
            )STRICT;

            CREATE TABLE IF NOT EXISTS Partie (
                ID INTEGER,
                Nom TEXT NOT NULL,
                ID_Salle INTEGER NOT NULL,
                PRIMARY KEY(ID AUTOINCREMENT),
                FOREIGN KEY(ID_Salle) REFERENCES Salle(ID)
            )STRICT;

            CREATE TABLE IF NOT EXISTS Enigmes (
                ID INTEGER,
                Question TEXT NOT NULL,
                Reponse_Correcte TEXT NOT NULL,
                Reponse_Fausse_1 TEXT NOT NULL,
                Reponse_Fausse_2 TEXT NOT NULL,
                ID_Salle INTEGER NOT NULL,
                PRIMARY KEY(ID AUTOINCREMENT),
                UNIQUE(Question),
                UNIQUE(Reponse_Correcte),
                FOREIGN KEY(ID_Salle) REFERENCES Salle(ID)
            )STRICT;
            
         
";
            tableCmd.ExecuteNonQuery();
            databaseConnection.Close();
        }

        public static Dictionary<string,object> ObtainRandomQuestion(int salle)
        {
            databaseConnection.Open();
            var listeObjetDansTable = new List<Dictionary<string,object>>();
            int tableSize = -1;
            string SQLiteQuery = $"SELECT * FROM enigmes WHERE ID_Salle = {salle}";
            using (SqliteCommand databaseCommand = new SqliteCommand(SQLiteQuery, databaseConnection))
            {
                using (SqliteDataReader databaseReader = databaseCommand.ExecuteReader())
                {
                    while (databaseReader.Read())
                    {
                        var ligneDeLaTable = new Dictionary<string, object>();

                        for (int i = 0; i < databaseReader.FieldCount; i++)
                        {
                            ligneDeLaTable[databaseReader.GetName(i)] = databaseReader.GetValue(i);
                        }

                        listeObjetDansTable.Add(ligneDeLaTable);
                        tableSize += 1;
                    }
                    databaseConnection.Close();
                    int idEnigmeChoisie = rand.Next(0, tableSize);
                    return listeObjetDansTable[idEnigmeChoisie];
                }
            }
            
        }
    }
}
