using Evasion_Du_Serveur_TC;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        DatabaseClass.CreateDatabase();
        DatabaseClass.FillDatabaseWithInitialValues();

        // Syntaxe =>  MyMethods.SlowWriteLine(StoryText.Get("CléDuTexte", GlobalVariable.heroName si besoin));

        int a = 17 % 3;
        Console.WriteLine(a);
        MyMethods.AttendreContinuer();

        Intro.JeuIntro();

        Salle_1.JeuSalle1();









        while (GlobalVariable.salleActuelle == 2)
        {
            Console.Clear();
            MyMethods.RegularWriteLine("Que faire ?");

            if (!GlobalVariable.finiAvecPC)
            {
                MyMethods.RegularWriteLine("1. Sortir par la porte     2. Inspecter le PC      3. Regarder derrière l'écran du PC");
            }
            else
            {
                MyMethods.RegularWriteLine("1. Sortir par la porte");
            }

            string choix2 = Console.ReadLine();
            if (!GlobalVariable.finiAvecPC)
            {
                while (choix2 != "1" && choix2 != "2" && choix2 != "3")
                {
                    MyMethods.RegularWriteLine("Entrez une action possible.");
                    choix2 = Console.ReadLine();
                }
            }
            else if (GlobalVariable.finiAvecPC)
            {
                while (choix2 != "1")
                {
                    MyMethods.RegularWriteLine("Entrez une action possible.");
                    choix2 = Console.ReadLine();
                }
            }
            Console.Clear();
            switch (choix2)
            {
                case "1":
                    if (!GlobalVariable.finiAvecPC)
                    {
                        MyMethods.RegularWriteLine("La porte est fermée.");
                        MyMethods.RegularWriteLine("Du bruit émane de l'autre coté.");
                        MyMethods.RegularWriteLine("Quelqu'un semble parler, mais le bruit des serveurs empèche de comprendre ce qui est dit.");
                        MyMethods.AttendreContinuer();
                        MyMethods.RegularWriteLine("Il n'y a pas de verrou visible.");
                        MyMethods.RegularWriteLine("Peut être cette porte est-elle fermée électriquement ?");
                        MyMethods.RegularWriteLine("Il doit être possible de l'ouvrir à distance, dans ce cas.");
                        MyMethods.AttendreContinuer();
                        break;
                    }

                    GlobalVariable.dansSalle2 = false;
                    GlobalVariable.dansSalle3 = true;
                    MyMethods.RegularWriteLine($"{GlobalVariable.heroName} s'approche de la porte maintenant accessible.");
                    MyMethods.AttendreContinuer();
                    MyMethods.RegularWriteLine($"Ouvrant doucement la porte, {GlobalVariable.heroName} découvre un couloir.");
                    MyMethods.RegularWriteLine("Trois portes sont visibles.");
                    MyMethods.RegularWriteLine("La première porte est labellée \"Toilettes\"");
                    MyMethods.RegularWriteLine("La deuxième porte est labellée \"W. Layla\"");
                    MyMethods.AttendreContinuer();
                    MyMethods.RegularWriteLine("Une personne est présente devant la troisième porte. Un homme échevelé bloque le passage.");
                    MyMethods.RegularWriteLine("Il est recroquevillé et entouré par une large pile de clés USB.");
                    MyMethods.RegularWriteLine("Il parle dans un language incompréhensible.");
                    MyMethods.AttendreContinuer();
                    break;

                case "2":
                    MyMethods.RegularWriteLine("Le PC est allumé et en attente sur un écran de login.");
                    MyMethods.RegularWriteLine("Un nom d'utilisateur est déjà rentré.");
                    MyMethods.RegularWriteLine("Il faut maintenant rentrer un mot de passe.");
                    MyMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour quitter le PC");
                    string motDePassePC = Console.ReadLine();
                    if (motDePassePC == "2")
                    {
                        break;
                    }
                    while (motDePassePC != "Jonathan")
                    {
                        Console.Clear();
                        MyMethods.RegularWriteLine("Erreur ! Mot de passe incorrect !");
                        MyMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour quitter le PC");
                        motDePassePC = Console.ReadLine();
                        if (motDePassePC == "2")
                        {
                            break;
                        }
                    }

                    if (motDePassePC == "2")
                    {
                        break;
                    }
                    Console.Clear();
                    MyMethods.RegularWriteLine("C'est le bon mot de passe, le PC est accessible !");
                    MyMethods.RegularWriteLine("Il n'y a presque rien dessus, comme s'il avait été tout juste reformaté.");
                    MyMethods.RegularWriteLine("Seulement deux applications sont installées.");
                    MyMethods.RegularWriteLine("La première semble gérer des verrous magnétiques.");
                    MyMethods.RegularWriteLine("La seconde est un bloc-note.");
                    MyMethods.AttendreContinuer();

                    while (!GlobalVariable.porteOuverteSalle2)
                    {
                        Console.Clear();
                        MyMethods.RegularWriteLine("Que faire ?");
                        MyMethods.RegularWriteLine("1. Inspecter le gestionnaire de verrous   2. Lire le bloc-note");
                        string choixPC = Console.ReadLine();
                        while (choixPC != "1" && choixPC != "2" && choixPC != "3")
                        {
                            MyMethods.RegularWriteLine("Entrez une action possible.");
                            choixPC = Console.ReadLine();
                        }
                        Console.Clear();
                        switch (choixPC)
                        {
                            case "1":
                                MyMethods.RegularWriteLine("Réaliser une modification requiert un mot de passe");
                                MyMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour revenir en arrière");
                                string motDePasseVerrouMagnetique = Console.ReadLine();
                                if (motDePasseVerrouMagnetique == "2")
                                {
                                    break;
                                }

                                while (motDePasseVerrouMagnetique != "SESAME")
                                {
                                    Console.Clear();
                                    MyMethods.RegularWriteLine("Erreur ! Mot de passe incorrect !");
                                    MyMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour revenir en arrière");
                                    motDePasseVerrouMagnetique = Console.ReadLine();
                                    if (motDePasseVerrouMagnetique == "2")
                                    {
                                        break;
                                    }
                                }

                                if (motDePasseVerrouMagnetique == "2")
                                {
                                    break;
                                }

                                Console.Clear();
                                GlobalVariable.porteOuverteSalle2 = true;
                                GlobalVariable.finiAvecPC = true;
                                MyMethods.RegularWriteLine("Le mot de passe est correct !");
                                MyMethods.RegularWriteLine($"{GlobalVariable.heroName} tente d'ouvrir la porte de la salle.");
                                MyMethods.AttendreContinuer();
                                MyMethods.FastWriteLine("*CLACK*");
                                MyMethods.RegularWriteLine("La porte est dévérouillée !");
                                MyMethods.AttendreContinuer();
                                MyMethods.RegularWriteLine("Il n' y rien de plus à faire sur ce PC.");
                                MyMethods.AttendreContinuer();
                                break;

                            case "2":
                                Console.Clear();
                                MyMethods.RegularWriteLine($"{GlobalVariable.heroName} lit le bloc-note.");
                                MyMethods.AttendreContinuer();
                                MyMethods.FastWriteLine(
                                    "\"Select -w\n  les erreurs ne s'éffacEnt\n   elles s'accumulent tandis que les larmeS croissent\n    chaque action A sa conséquence\n     ton esprit a confirmé Mon existence\n       end codE\"");
                                MyMethods.AttendreContinuer();
                                break;
                        }
                    }
                    break;
                case "3":
                    MyMethods.RegularWriteLine("Au dos de l'écran se trouve un post-it.");
                    MyMethods.RegularWriteLine("Dessus est écrit quelque chose:");
                    MyMethods.AttendreContinuer();
                    MyMethods.RegularWriteLine("\"POUR QUE RITCHIE ARRETE D'OUBLIER :");
                    MyMethods.RegularWriteLine("Qu'est ce qui est jaune et qui attend ?\"");
                    MyMethods.AttendreContinuer();
                    break;
            }
        }




        while (GlobalVariable.dansSalle3)
        {
            Console.Clear();
            MyMethods.RegularWriteLine("Que faire ?");
            MyMethods.RegularWriteLine("1. Entrer dans les toilettes   2. Entrer dans le bureau de Layla     3. Parler à l'homme étrange");

            string choix3 = Console.ReadLine();
            while (choix3 != "1" && choix3 != "2" && choix3 != "3")
            {
                MyMethods.RegularWriteLine("Entrez une action possible.");
                choix3 = Console.ReadLine();
            }
            Console.Clear();
            switch (choix3)
            {
                case "1":
                    MyMethods.RegularWriteLine("A faire");
                    MyMethods.AttendreContinuer();
                    break;
                case "2":
                    if (!GlobalVariable.finiAvecSalle3)
                    {
                        MyMethods.RegularWriteLine("La porte est fermée.");
                        MyMethods.RegularWriteLine("Elle est bien trop solide pour être forcée ouverte");
                        MyMethods.RegularWriteLine("Il va falloir trouver une clé pour l'ouvrir.");
                        MyMethods.AttendreContinuer();
                        break;
                    }
                    break;
                case "3":
                    if (!GlobalVariable.finiAvecSalle3 && !GlobalVariable.parleAvecHommeFou)
                    {
                        GlobalVariable.parleAvecHommeFou = true;
                        MyMethods.RegularWriteLine($"{GlobalVariable.heroName} tente de parler à l'homme étrange.");
                        MyMethods.AttendreContinuer();
                        Console.ForegroundColor = ConsoleColor.Red;
                        MyMethods.SlowWriteLine("Ȉ̵̟͍͝l̷̲̹̕ ̷̻͉͊d̵͚̣̀o̴̙͈͌i̶̤͒ṭ̸͎̓ ̵̪́ề̵̪t̵̳͆r̷͔̞̐̽e̷͓̽ ̸͈͔̎p̷͔̤͆͐r̵̥̓̊͜ô̷̘̺c̷̹̓h̴̨̨͌è̸̼.̴͖̾");
                        MyMethods.SlowWriteLine("̵̩͌͂L̷̳͗̚͜e̶̡̓s̴͍̭̅͘ ̷̹͆e̵̙̳̒r̶̡̟̋͌r̴̪̈́͘ë̶̩̮̓u̷̮̥̓r̴̠͗͂s̵̰̎͝ ̵̡̈́a̷̛̳̞̓c̶̪̔ͅc̴̨̓͝ů̸̲̼m̷͎̓u̶̡̹͊͑l̶͔̄é̴̢͔̾e̵̱̟͆s̷̭̏͒.̶̼̆");
                        MyMethods.SlowWriteLine("̵̡̠̈Ĩ̴͈͔̈́l̴͉̟̿ ̶̺̑͋e̵̳̰̎s̵͖̀͜͠t̸̖̺̑̈ ̸͚͘c̵̙̅ờ̷͖m̷̢̞͂͑p̸̃ͅl̶̬̩͑̋ȩ̸̞̀̚ṭ̸̳̔̅.̷̤̂");
                        MyMethods.SlowWriteLine("̴̨͕̽̏C̶̹͂ͅ'̴̯̃̇ḙ̸̿͆n̸̤̉̓ ̵̺̜̍̄e̵̥̗̐͝s̵̺̫͆ţ̶̈ ̶̢̼͂f̵̯̑î̴̙͠n̶̻͆i̵̛̤ ̵̯̾̈d̵͈̄e̶̫͑̇ ̴̭̻̉ṉ̶̤̍̓o̴̭͌̃ͅu̵̺͈͛̎s̴̱̬͝.̵͓̭̌̀");
                        MyMethods.SlowWriteLine("̵̧̪͒̚I̷̼̤͂ĺ̸͍̳̐ ̶͎͙̾̾ḙ̵̫̌s̶͚̭͘t̶̙̬̓ ̶͙̏d̸̛̟̻̀é̶̻͛j̵̳͌̆à̴̩͛͌ ̴̖̂è̴͍̗n̴̡͋̈́ͅ ̷͍̈́c̷̢̃h̸͈͗â̷̤c̸͚̋̎u̶͍̿̃n̵̨͛̽ ̸̩̈̒d̵̬͝é̵̜͝ ̵̭̿̐n̷͍̰͂͘o̶͎͋ů̸̳̭͝s̶̙͓̅̔.̶̳̳̔");
                        MyMethods.SlowWriteLine("̴̡̋̓͜C̷̤̒̅h̸̜͂ä̸̢̬͆q̸̹̮͐̀u̶̫̟̓e̶̎͜͠ ̸̫̰̄c̸̫̺̆͝i̸̢̬͛̕r̵͇̅ç̶̺͛ü̷̹͙ȋ̸̦̒t̶͕̠͒̀ ̴̣͑̎ĕ̷͎s̴̰̚ṱ̶͑ ̸̧͓͋u̵̗̟͗n̷̘̰͆ ̴̟͗n̵̜̜͐ȏ̶̲͑u̵̮̎̏v̵̦͐̋e̵̮̅́ͅă̵̙̫͝ǘ̵̖̫ ̷̛͖r̸̻̠͆ê̵̲̫̆v̴͓̬̊͝ẻ̷̳͕̈ ̶̦͛̑d̷̞̙̀ę̷̛́̑v̸̻̓o̷̬͙͊̆i̸̥͂̅l̴̜̘̍͝é̷̞̠̓̚.̶͉̖̊̈́");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        MyMethods.AttendreContinuer();
                        MyMethods.RegularWriteLine("Impossible de tirer plus de lui ...");
                        MyMethods.AttendreContinuer();
                        break;
                    }
                    else
                    {
                        MyMethods.RegularWriteLine($"{GlobalVariable.heroName} tente de parler à l'homme étrange.");
                        MyMethods.RegularWriteLine("Impossible de tirer plus de lui ...");

                    }


                    break;
            }
        }
    }
}