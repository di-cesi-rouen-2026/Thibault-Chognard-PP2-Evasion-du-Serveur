using Microsoft.Data.Sqlite;

namespace Evasion_Du_Serveur_TC
{
    internal class DatabaseClass
    {
        public static SqliteConnection databaseConnection = new SqliteConnection("DataSource=DatabaseEvasionServeur.db");
        

        public static void CreateDatabase()
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
            tableCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Partie(
                ID INTEGER,
                PV_Joueur INTEGER NOT NULL,
                Obtenu_Hache INT NOT NULL,
                Nom_Joueur TEXT NOT NULL,
                PRIMARY KEY(ID AUTOINCREMENT),
                UNIQUE(Nom_Joueur)
            )STRICT;

            CREATE TABLE IF NOT EXISTS Salle(
                ID INTEGER,
                Nom_Salle TEXT NOT NULL,
                PRIMARY KEY(ID AUTOINCREMENT),
                UNIQUE(Nom_Salle)
            )STRICT;

            CREATE TABLE IF NOT EXISTS Enigmes(
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

            CREATE TABLE IF NOT EXISTS Sauvegarder(
                ID_Partie INTEGER,
                ID_Salle INTEGER,
                PRIMARY KEY(ID_Partie, ID_Salle),
                FOREIGN KEY(ID_Partie) REFERENCES Partie(ID),
                FOREIGN KEY(ID_Salle) REFERENCES Salle(ID)
            )STRICT;";
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
                    int idEnigmeChoisie = GlobalVariable.rand.Next(0, tableSize+1);
                    return listeObjetDansTable[idEnigmeChoisie];
                }
            }
            
        }

        public static void CréerNouvellePartie(string nomHero)
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
             tableCmd.CommandText = $"INSERT INTO Partie SET (Nom_Joueur,PV_Joueur,Obtenu_Hache,) VALUES (@nomHero,@PV_Restant,@Obtenu_Hache)";
            tableCmd.Parameters.AddWithValue("@nomHero", nomHero);
            tableCmd.Parameters.AddWithValue("@PV_Restant", 3);
            tableCmd.Parameters.AddWithValue("@Obtenu_Hache", 0);

            tableCmd.ExecuteNonQuery();
            databaseConnection.Close();
        }
    }
}
