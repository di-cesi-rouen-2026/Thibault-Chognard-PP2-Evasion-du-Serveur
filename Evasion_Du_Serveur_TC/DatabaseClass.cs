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
        public static void FillDatabaseWithInitialValues()
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
            tableCmd.CommandText =
                @"INSERT OR IGNORE INTO Salle (Nom_Salle) VALUES ('Bureau'), ('Salle de repos'), ('Cour intérieure'), ('Couloir'), ('Salle des serveurs');

                INSERT OR IGNORE INTO Enigmes (Question, Reponse_Correcte, Reponse_Fausse_1, Reponse_Fausse_2, ID_Salle) Values
                ('Quel type de donnée permet de stocker des nombres entier ?','Integer', 'String', 'Bool', 1),
                ('Que permet une boucle FOR ?','Itérer un bout de code un nombre de fois précis', 'Préciser à quoi sert une partie de code', 'A représenter le nombre 4', 1),
                ('Dans lequel de ces cas parle-t-on de concaténation ?', 'Coller ensemble des textes en format string', 'Additionner des nombres', 'Supprimer une base de donnée', 1),
                ('Que permet une boucle WHILE ?','Itérer un bout de code un nombre de fois inconnu', 'Faire marcher un bout de code en parallèle à un autre', 'Uniquement rendre des saisies de données incassables', 1),
                ('Quelle est la différence entre un type DOUBLE et un type FLOAT', 'Le type double stocke des chiffres à un plus grand degré de précision après la virgule', 'Ils sont identiques', 'Le type float stocke des chiffres à un plus grand degré de précision après la virgule', 1),
                ('Quel est le nom entier du type BOOL en francais','Booléen','Booling','Boolvar', 1),
                ('En C#, est il nécessaire de préciser le type d''une variable lors de sa déclaration?', 'Oui, c''est nécessaire', 'Non', 'Il n''est possible de déclarer des variables que en Python', 1),
                ('Une boucle while(true) s''exécute combien de fois ?','Un nombre infini de fois sans forcer la sortie de la boucle', '1 fois', '4 fois car il y a 4 lettres dans true', 1),
                ('Deux conditions if peuvent elles être imbriquées l''une dans l''autre ?', 'Oui, elles le peuvent', 'Non', 'Uniquement si le language local du système est configuré en Portugais', 1),
                ('Quel est le résultat de 17%3 ?', '2', '3', '3.4', 1),
                ('En C#, quel opérateur logique représente OU ?', '||', '<>', 'OR', 1),
                ('En C#, si (int a = 9; integer b = 10;), quel est le résultat de (b + a) ?', 'Une erreur, integer n''est pas un type utilisable en C#', '19', '21', 1),
                ('A quoi sert un SWITCH CASE ?', 'Exécuter différents bouts de code en fonction de la valeur d''une variable', 'Changer de case dans un tableau Excel', 'Le SWITCH CASE n''existe pas', 1),
                ('Que se passe-t-il si une condition IF est définie sans ELSE', 'La condition IF est ignorée et le code continue à s''exécuter', 'Le programme plante', 'Le programme tourne à l''infini en cherchant un ELSE', 1),
                ('Quelle valeur à 0 quand traduit en BOOL ?', 'False', 'True', 'NULL', 1),
                ('Quel est le numéro du premier indice d''un tableau', '0', '1', 'Les tableaux n''ont pas d''indices', 1);";
            tableCmd.ExecuteNonQuery();
            databaseConnection.Close();
        }

        public static Dictionary<string,object> ObtainRandomQuestion(int salle)
        {
            databaseConnection.Open();
            List<Dictionary<string, object>> listeEnigme = new List<Dictionary<string,object>>();
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

                        listeEnigme.Add(ligneDeLaTable);
                        tableSize += 1;
                    }
                    databaseConnection.Close();
                    int idEnigmeChoisie = GlobalVariable.rand.Next(0, tableSize + 1);

                    return listeEnigme[idEnigmeChoisie];
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
