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
                Nom_Joueur TEXT NOT NULL,
                Nom_Hero TEXT NOT NULL,
                PV_Hero INTEGER NOT NULL,
                Deja_Perdu_PV INTEGER NOT NULL,
                Hache_Obtenue INTEGER NOT NULL,
                Hache_Utilisee INTEGER NOT NULL,
                ID_Salle INTEGER NOT NULL,
                PRIMARY KEY(ID AUTOINCREMENT),
                UNIQUE(Nom_Joueur),
                FOREIGN KEY(ID_Salle) REFERENCES Salle(ID)
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
            string SQLiteQuery = $"SELECT * FROM enigmes WHERE ID_Salle = {salle};";
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

        public static void CréerNouvellePartie(string nomJoueur, string nomHero)
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
            tableCmd.CommandText = $"INSERT INTO Partie" +
                                   $"SET (Nom_Joueur, Nom_Hero, PV_Hero, Deja_Perdu_PV, Hache_Obtenue, Hache_Utilisee)" +
                                   $"VALUES (@NomJoueur, @NomHero,@PV_Hero, @DejaPerduPV, @HacheObtenue, @HacheUtilisee);";
            tableCmd.Parameters.AddWithValue("@NomJoueur", nomJoueur);
            tableCmd.Parameters.AddWithValue("@NomHero", nomHero);
            tableCmd.Parameters.AddWithValue("@PV_Hero", 3);
            tableCmd.Parameters.AddWithValue("@DejaPerduPV", 0);
            tableCmd.Parameters.AddWithValue("@HacheObtenue", 0);
            tableCmd.Parameters.AddWithValue("@HacheUtilisee", 0);

            tableCmd.ExecuteNonQuery();
            databaseConnection.Close();
        }
        public static void EnregistrerPartie(string nomJoueur, string nomHero, string salle, int pvRestant, int hacheObtenue, int hacheUtilisee)
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
            tableCmd.CommandText = $"UPDATE Partie SET (PV_Hero = {pvRestant}, Hache_Obtenue = {hacheObtenue}, Hache_Utilisee = {hacheUtilisee}, ID_Salle = {salle}) WHERE Nom_Hero = @nomHero AND Nom_Joueur = @nomJoueur;";
            tableCmd.Parameters.AddWithValue("@nomJoueur", nomJoueur);
            tableCmd.Parameters.AddWithValue("@nomHero", nomHero);

            tableCmd.ExecuteNonQuery();
            databaseConnection.Close();
        }
        public static void ChargerPartie(string nomJoueur, string nomHero)
        {
            databaseConnection.Open();
            var listeObjetDansTable = new Dictionary<string, object>();
            var SQLiteQuery = $"Select * FROM Partie WHERE Nom_Hero = {nomHero} AND Nom_Joueur = {nomJoueur};";

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

                        listeObjetDansTable = ligneDeLaTable;
                    }
                    databaseConnection.Close();
                    GlobalVariable.heroName = listeObjetDansTable["Nom_Hero"].ToString();
                    GlobalVariable.pvRestant = Convert.ToInt32(listeObjetDansTable["PV_Hero"]);
                    GlobalVariable.dejaPerduPV = MyMethods.ChangerIntEnBool(Convert.ToInt32(listeObjetDansTable["Deja_Perdu_PV"]));
                    GlobalVariable.hacheObtenue = MyMethods.ChangerIntEnBool(Convert.ToInt32(listeObjetDansTable["hache_Obtenue"]));
                    GlobalVariable.hacheUtilisee = MyMethods.ChangerIntEnBool(Convert.ToInt32(listeObjetDansTable["Hache_Utilisee"]));
                    GlobalVariable.salleActuelle = (Convert.ToInt32(listeObjetDansTable["ID_Salle"]));
                }
            }

            databaseConnection.Close();
        }
    }
}
