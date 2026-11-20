using Microsoft.Data.Sqlite;

namespace EscapeGameTC
{
    internal class DatabaseClass
    {
        public static SqliteConnection databaseConnection = new SqliteConnection("DataSource=DatabaseTEST.db");


        public static void CreateDatabase()
        {
            databaseConnection.Open();
            var tableCmd = databaseConnection.CreateCommand();
            tableCmd.CommandText = @"
            CREATE TABLE Salle(
                ID INTEGER,
                Nom TEXT NOT NULL,
                PRIMARY KEY(ID),
                UNIQUE(Nom)
            );

            CREATE TABLE Partie(
                ID INTEGER,
                Nom TEXT NOT NULL,
                ID_Salle INTEGER NOT NULL,
                PRIMARY KEY(ID),
                FOREIGN KEY(ID_Salle) REFERENCES Salle(ID)
            );

            CREATE TABLE Enigmes(
                ID INTEGER,
                Question TEXT NOT NULL,
                Reponse_Correcte TEXT NOT NULL,
                Reponse_Fausse_1 TEXT NOT NULL,
                Reponse_Fausse_2 TEXT NOT NULL,
                ID_Salle INTEGER NOT NULL,
                PRIMARY KEY(ID),
                UNIQUE(Question),
                UNIQUE(Reponse_Correcte),
                FOREIGN KEY(ID_Salle) REFERENCES Salle(ID)
            );";
            tableCmd.ExecuteNonQuery();
            databaseConnection.Close();
        }

    }
}
