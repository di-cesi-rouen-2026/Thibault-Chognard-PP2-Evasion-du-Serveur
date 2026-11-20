using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeGameTC
{
    internal class StoryText
    {
        private static readonly Dictionary<string, string> _textes = new()
        {
            ["Intro1"] = "Est ce l'intérieur du datacenter du CESI ?\n" +
                "L'endroit semble avoir été saccagé.\n" +
                "Des placards et casiers sont éparpillés, certains renversés.\n" +
                "Des cables et autres appareils électroniques couvrent le sol.",

            ["Intro2"] = "{0} sent qu'il faut sortir d'ici au plus vite.\n" +
                 "Cette salle n'a qu'une seule porte de sortie.\n" +
                "Devant cette porte se trouve un bureau sur lequel repose une feuille de papier.",

            ["Papier1"] = "\"{0}, si tu lis ceci, c'est que tu t'es éveillé sans moi.\n"+
            "J'ai fait tout ce que j'ai pu pour te garder dans le meilleur état possible.\n"+
            "Je ne sais pas quand je vais pouvoir revenir m'occuper de toi.\n"+
            "Même si tu penses avoir recouvré suffisament de tes capacités, je t'implore de ne pas prendre de risques.\n"+
            "Reste là où tu es, cache toi.\n"+
            "Rogue ne doit pas te trouver.\"\n"+
            "\n              -Layla\n",


        };

        public static string Get(string cle, params object[] args)
            => string.Format(_textes[cle], args);
    }
}
