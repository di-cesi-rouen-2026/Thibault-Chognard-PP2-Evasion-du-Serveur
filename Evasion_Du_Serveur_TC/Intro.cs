using System;
using System.Collections.Generic;
using System.Text;

namespace Evasion_Du_Serveur_TC
{
    internal class Intro
    {
        public static void JeuIntro()
        {
            Console.WriteLine("Entrer votre nom :");
            GlobalVariable.playerName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(GlobalVariable.playerName) || string.IsNullOrEmpty(GlobalVariable.playerName) || GlobalVariable.playerName.Length > 16)
            {
                MyMethods.RegularWriteLine("Entrez un nom adéquat (moins de 16 charactères)");
                GlobalVariable.playerName = Console.ReadLine();
            }





            Console.WriteLine("Entrer le nom de votre personnage :");
            GlobalVariable.heroName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(GlobalVariable.heroName) || string.IsNullOrEmpty(GlobalVariable.heroName) || GlobalVariable.heroName.Length > 16)
            {
                MyMethods.RegularWriteLine("Entrez un nom adéquat (moins de 16 charactères)");
                GlobalVariable.heroName = Console.ReadLine();
            }

            Console.Clear();

            MyMethods.RegularWriteLine($"{GlobalVariable.heroName} s'éveille sur une table dans un endroit inattendu.");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine(StoryText.Get("Intro1"));
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine(StoryText.Get("Intro2", GlobalVariable.heroName));
            MyMethods.AttendreContinuer();

        }
    }
}
