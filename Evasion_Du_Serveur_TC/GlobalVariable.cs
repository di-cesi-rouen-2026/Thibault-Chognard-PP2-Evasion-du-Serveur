using System;
using System.Collections.Generic;
using System.Text;

namespace Evasion_Du_Serveur_TC
{
    internal class GlobalVariable
    {
        public static Random rand = new Random();
        public static int pvRestant = 3;
        public static bool dejaPerduPV = false;
        public static string heroName = "";

        public static Stack<string> salleActuelle = new();
        public static bool dansSalle1 = true;
        public static bool casiersFouilles = false;
        public static bool terminalInspecte = false;
        public static bool finiPremiereEnigme = false;
        public static bool finiEnigmesSalle1 = false;
        public static string preventionSortieSalle1 = "";
        public static Dictionary<string, string> menuSalle1 = new Dictionary<string, string>
        {
            ["1"] = "S'approcher du terminal",
            ["2"] = "Fouiller les casiers"
        };

        public static bool dansSalle2 = false;
        public static bool finiAvecPC = false;
        public static bool porteOuverteSalle2 = false;


        public static bool dansSalle3 = false;
        public static bool parleAvecHommeFou = false;
        public static bool finiAvecSalle3 = false;


        public static bool dansSalle4 = false;
        public static bool dansSalle5 = false;
        public static bool dansSalle6 = false;

    }
}
