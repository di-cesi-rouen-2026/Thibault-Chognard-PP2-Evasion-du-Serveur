using Evasion_Du_Serveur_TC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evasion_Du_Serveur_TC
{
    internal class Salle_1
    {
        public static void JeuSalle1()
        {
            while (GlobalVariable.salleActuelle.Peek() == "1")
            {
                Console.Clear();
                MyMethods.ImprimerPV();
                MyMethods.RegularWriteLine("Que faire ?");
                MyMethods.WriteMenu(GlobalVariable.menuSalle1);
                string choix1 = Console.ReadLine();

                if (!GlobalVariable.hacheObtenue)
                {
                    while (choix1 != "1" && choix1 != "2")
                    {
                        MyMethods.RegularWriteLine("Entrez 1 ou 2 pour choisir quoi faire.");
                        choix1 = Console.ReadLine();
                    }
                }
                else
                {
                    while (choix1 != "1")
                    {
                        MyMethods.RegularWriteLine("Entrez 1 pour continuer.");
                        choix1 = Console.ReadLine();
                    }
                }
                Console.Clear();
                switch (choix1)
                {
                    case "1":
                        if (!GlobalVariable.terminalInspecte)
                        {
                            MyMethods.RegularWriteLine(StoryText.Get("ApprocheTerminalSalle1", GlobalVariable.heroName));
                            MyMethods.AttendreContinuer();
                            MyMethods.RegularWriteLine(StoryText.Get("ApprocheTerminalSalle2", GlobalVariable.heroName));
                            MyMethods.AttendreContinuer();
                            MyMethods.RegularWriteLine(StoryText.Get("ApprocheTerminalSalle3"));
                            MyMethods.AttendreContinuer();
                            MyMethods.RegularWriteLine(StoryText.Get("ApprocheTerminalSalle4"));
                            MyMethods.AttendreContinuer();
                            GlobalVariable.menuSalle1["1"] = "Tenter de résoudre une énigme";
                            GlobalVariable.terminalInspecte = true;
                            break;
                        }
                        else if (!GlobalVariable.finiEnigmesSalle1)
                        {
                            if (!GlobalVariable.finiPremiereEnigme)
                            {
                                MyMethods.RegularWriteLine(StoryText.Get("LectureEnigmeSalle1", GlobalVariable.heroName));
                                MyMethods.AttendreContinuer();
                                Dictionary<string, object> question = DatabaseClass.ObtainRandomQuestion(1);
                                MyMethods.HandleQuestion(question);
                                break;
                            }
                            else
                            {
                                Dictionary<string, object> question = DatabaseClass.ObtainRandomQuestion(1);
                                MyMethods.HandleQuestion(question);
                                break;
                            }
                        }
                        break;
                    case "2":
                        GlobalVariable.hacheObtenue = true;
                        GlobalVariable.menuSalle1.Remove("2");
                        GlobalVariable.preventionSortieSalle1 = "";
                        MyMethods.RegularWriteLine(StoryText.Get("CasierFouiller", GlobalVariable.heroName));
                        MyMethods.AttendreContinuer();
                        break;
                }
                    /*
                    if (!Global.casiersFouilles)
                    {
                        TextMethods.FastWriteLine("Cette action est irréversible. Est-vous sûr de vouloir quitter la salle ?");
                        TextMethods.RegularWriteLine("1. Sortir   2. Ne pas sortir tout de suite");
                        preventionSortieSalle1 = Console.ReadLine();

                    }
                    if (Global.preventionSortieSalle1 == "2")
                    {
                        break;
                    }
                    Console.Clear();
                    Global.dansSalle1 = false;
                    Global.dansSalle2 = true;
                    break;
                    */
            }


        }
    }
}
