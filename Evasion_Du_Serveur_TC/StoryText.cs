using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeGameTC
{
    internal class StoryText
    {
        private static readonly Dictionary<string, string> textes = new()
        {
            ["Intro1"] = "Est ce l'intérieur du datacenter du CESI ?\n" +
                "L'endroit semble avoir été saccagé.\n" +
                "Des placards et casiers sont éparpillés, certains renversés.\n" +
                "Des cables et autres appareils électroniques couvrent le sol.",

            ["Intro2"] = "{0} sent qu'il faut sortir d'ici au plus vite.\n" +
                 "Cette salle n'a qu'une seule porte de sortie.\n" +
                 "C'est une grande porte métallique, un terminal d'accès est fixé au mur.",

            ["CasierFouiller"] ="{0} fouille les casiers et placards\n" +
                "Il ne semble n'y avoir rien d'utile dans les premiers ...\n" +
                "Ni dans les suivants ...\n" +
                "Oh ! Le dernier placard contient une hache de pompier !\n" +
                "Hmmm ... C'est du plastique.\n" +
                "Ca reste relativement solide, et faute de mieux, {0} prend la hache.",

            ["ApprocheTerminalSalle1"] = "{0} s'approche du terminal et celui-ci s'allume immédiatement.\n" +
                "Une voix robotique résonne dans la pièce :\n" +
                "\"喔，哈囉！看到你還活著，我很驚訝。\"",

            ["ApprocheTerminalSalle2"] = "La voix se tait et, en réponse à la confusion visible sur le visage de {0}, reprend quelques secondes plus tard :\n" +
                "\"Oh là, ca va mal ! Tu n'es même plus capable de comprendre autre chose que le français ?\"\n" +
                "\"Sais tu, au moins, ce que tu fais ici ? Pourquoi tu es enfermé dans cette pièce ?\"",

            ["ApprocheTerminalSalle3"] = "\"Non ? C'est bien la première fois que tu m'apportes une bonne nouvelle !\"\n" +
                "\"Excellent ! Excellent ! Dans ce cas, je vais te laisser moisir ici encore quelque temps.\"\n" +
                "\"Tu peux essayer de résoudre les enigmes servant de verrou à cette porte, mais je t'avoue que je doute que tu puisses y arriver dans ton état.\"",

            ["ApprocheTerminalSalle4"] = "\"Ciao, j'ai d'autres rats à exterminer !\"\n" +
                "Le son se coupe et laisse place au silence.",

            ["LectureEnigmeSalle1"] = "Le terminal présente une interface simple.\n" +
                "Une question et trois bouttons avec des réponses différentes.\n" +
                "{0} ne sait pas quelles répercussions découlerons de choisir la mauvaise réponse.\n" +
                "Rien ne semble presser une réponse rapide.\n" +
                "Mieux vaut prendre son temps pour réfléchir."
        };

        public static string Get(string cle, params object[] args)
            => string.Format(textes[cle], args);
    }
}
