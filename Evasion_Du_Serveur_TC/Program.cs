using EscapeGameTC;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        DatabaseClass.CreateDatabase();

        bool dansSalle1 = true;
        bool casiersFouilles = false;
        bool papierLu = false;
        string preventionSortieSalle1 = "";

        bool dansSalle2 = false;
        bool finiAvecPC = false;
        bool porteOuverteSalle2 = false;

        bool dansSalle3 = false;
        bool parleAvecHommeFou = false;
        bool finiAvecSalle3 = false;

        bool dansSalle4 = false;
        bool dansSalle5 = false;
        bool dansSalle6 = false;



        // Syntaxe =>  MyMethods.SlowWriteLine(StoryText.Get("CléDuTexte", HeroName si besoin));



        Console.WriteLine("Entrer votre nom :");
        string heroName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(heroName) || string.IsNullOrEmpty(heroName) || heroName.Length > 14)
        {
            TextMethods.RegularWriteLine("Entrez un nom adéquat (moins de 14 charactères)");
            heroName = Console.ReadLine();
        }

        Console.Clear();

        TextMethods.RegularWriteLine($"{heroName} s'éveille sur une table dans un endroit inattendu.");
        TextMethods.AttendreContinuer();
        TextMethods.RegularWriteLine(StoryText.Get("Intro1"));
        TextMethods.AttendreContinuer();
        TextMethods.RegularWriteLine(StoryText.Get("Intro2", heroName));
        TextMethods.AttendreContinuer();

        while (dansSalle1)
        {
            Console.Clear();
            TextMethods.RegularWriteLine("Que faire ?");
            if (casiersFouilles && papierLu)
            {
                TextMethods.RegularWriteLine("1. Sortir par la porte");
            }
            else
            {
                Console.Write("1. Sortir par la porte");
            }
            if (!casiersFouilles && !papierLu)
            {
                TextMethods.RegularWriteLine("     2. Fouiller les casiers     3. Lire papier");
            }
            else if (casiersFouilles && !papierLu)
            {
                TextMethods.RegularWriteLine("     2. Lire papier");
            }
            else if (!casiersFouilles && papierLu)
            {
                TextMethods.RegularWriteLine("     2. Fouiller les casiers");
            }

            string choix1 = Console.ReadLine();
            if (!casiersFouilles && !papierLu)
            {
                while (choix1 != "1" && choix1 != "2" && choix1 != "3")
                {
                    TextMethods.RegularWriteLine("Entrez une action possible.");
                    choix1 = Console.ReadLine();
                }
            }
            else if (casiersFouilles && !papierLu)
            {
                while (choix1 != "1" && choix1 != "2")
                {
                    TextMethods.RegularWriteLine("Entrez une action possible.");
                    choix1 = Console.ReadLine();
                }
            }
            else if (!casiersFouilles && papierLu)
            {
                while (choix1 != "1" && choix1 != "2")
                {
                    TextMethods.RegularWriteLine("Entrez une action possible.");
                    choix1 = Console.ReadLine();
                }
            }
            else if (casiersFouilles && papierLu)
            {
                while (choix1 != "1")
                {
                    TextMethods.RegularWriteLine("Entrez une action possible.");
                    choix1 = Console.ReadLine();
                }
            }
            Console.Clear();
            switch (choix1)
            {
                case "1":
                    if (!casiersFouilles || !papierLu)
                    {
                        TextMethods.FastWriteLine("Cette action est irréversible. Est-vous sûr de vouloir quitter la salle ?");
                        TextMethods.RegularWriteLine("1. Sortir   2. Ne pas sortir tout de suite");
                        preventionSortieSalle1 = Console.ReadLine();

                    }
                    if (preventionSortieSalle1 == "2")
                    {
                        break;
                    }
                    Console.Clear();
                    dansSalle1 = false;
                    dansSalle2 = true;
                    TextMethods.RegularWriteLine("Rester ici n'apportera rien de plus.");
                    TextMethods.RegularWriteLine("Il n'y a rien d'autre à faire qu'avancer.");
                    TextMethods.RegularWriteLine($"{heroName} pousse la table hors du chemin.");
                    TextMethods.RegularWriteLine($"Prudemment, {heroName} ouvre la porte.");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine($"Une salle plus grande encore s'étent devant {heroName}.");
                    TextMethods.RegularWriteLine("Rangées après rangées d'ordinateurs remplissent l'espace.");
                    TextMethods.RegularWriteLine("Ce sont certainement des serveurs, mais qu'hébergent ils ?");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine("Dans un coin se trouve un bureau avec un PC accessible.");
                    TextMethods.RegularWriteLine("Peut être l'inspecter permettrait d'éclairer la situation.");
                    TextMethods.RegularWriteLine("Au delà de ca, une porte est accessible de l'autre coté de la salle.");
                    TextMethods.AttendreContinuer();
                    break;
                case "2":
                    if (casiersFouilles)
                    {
                        papierLu = true;
                        TextMethods.RegularWriteLine($"{heroName} lit la feuille sur la table.\nDessus figure un message :");
                        TextMethods.AttendreContinuer();
                        TextMethods.RegularWriteLine(StoryText.Get("Papier1", heroName));
                        preventionSortieSalle1 = "";
                        TextMethods.AttendreContinuer();
                        break;
                    }
                    casiersFouilles = true;
                    TextMethods.RegularWriteLine($"{heroName} fouille les casiers et placards");
                    TextMethods.RegularWriteLine("Il ne semble n'y avoir rien d'utile dans les premiers ...");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine("Ni dans les suivants ...");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine("Oh ! Le dernier placard contient une hache de pompier !");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine("Hmmm ... C'est du plastique.");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine($"Ca reste relativement solide, et faute de mieux, {heroName} prend la hache.");
                    preventionSortieSalle1 = "";
                    TextMethods.AttendreContinuer();
                    break;

                case "3":
                    papierLu = true;
                    TextMethods.RegularWriteLine($"{heroName} lit la feuille sur la table.\nDessus figure un message :");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine(StoryText.Get("Papier1", heroName));
                    preventionSortieSalle1 = "";
                    TextMethods.AttendreContinuer();
                    break;
            }

        }



        while (dansSalle2)
        {
            Console.Clear();
            TextMethods.RegularWriteLine("Que faire ?");

            if (!finiAvecPC)
            {
                TextMethods.RegularWriteLine("1. Sortir par la porte     2. Inspecter le PC      3. Regarder derrière l'écran du PC");
            }
            else
            {
                TextMethods.RegularWriteLine("1. Sortir par la porte");
            }

            string choix2 = Console.ReadLine();
            if (!finiAvecPC)
            {
                while (choix2 != "1" && choix2 != "2" && choix2 != "3")
                {
                    TextMethods.RegularWriteLine("Entrez une action possible.");
                    choix2 = Console.ReadLine();
                }
            }
            else if (finiAvecPC)
            {
                while (choix2 != "1")
                {
                    TextMethods.RegularWriteLine("Entrez une action possible.");
                    choix2 = Console.ReadLine();
                }
            }
            Console.Clear();
            switch (choix2)
            {
                case "1":
                    if (!finiAvecPC)
                    {
                        TextMethods.RegularWriteLine("La porte est fermée.");
                        TextMethods.RegularWriteLine("Du bruit émane de l'autre coté.");
                        TextMethods.RegularWriteLine("Quelqu'un semble parler, mais le bruit des serveurs empèche de comprendre ce qui est dit.");
                        TextMethods.AttendreContinuer();
                        TextMethods.RegularWriteLine("Il n'y a pas de verrou visible.");
                        TextMethods.RegularWriteLine("Peut être cette porte est-elle fermée électriquement ?");
                        TextMethods.RegularWriteLine("Il doit être possible de l'ouvrir à distance, dans ce cas.");
                        TextMethods.AttendreContinuer();
                        break;
                    }

                    dansSalle2 = false;
                    dansSalle3 = true;
                    TextMethods.RegularWriteLine($"{heroName} s'approche de la porte maintenant accessible.");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine($"Ouvrant doucement la porte, {heroName} découvre un couloir.");
                    TextMethods.RegularWriteLine("Trois portes sont visibles.");
                    TextMethods.RegularWriteLine("La première porte est labellée \"Toilettes\"");
                    TextMethods.RegularWriteLine("La deuxième porte est labellée \"W. Layla\"");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine("Une personne est présente devant la troisième porte. Un homme échevelé bloque le passage.");
                    TextMethods.RegularWriteLine("Il est recroquevillé et entouré par une large pile de clés USB.");
                    TextMethods.RegularWriteLine("Il parle dans un language incompréhensible.");
                    TextMethods.AttendreContinuer();
                    break;

                case "2":
                    TextMethods.RegularWriteLine("Le PC est allumé et en attente sur un écran de login.");
                    TextMethods.RegularWriteLine("Un nom d'utilisateur est déjà rentré.");
                    TextMethods.RegularWriteLine("Il faut maintenant rentrer un mot de passe.");
                    TextMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour quitter le PC");
                    string motDePassePC = Console.ReadLine();
                    if (motDePassePC == "2")
                    {
                        break;
                    }
                    while (motDePassePC != "Jonathan")
                    {
                        Console.Clear();
                        TextMethods.RegularWriteLine("Erreur ! Mot de passe incorrect !");
                        TextMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour quitter le PC");
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
                    TextMethods.RegularWriteLine("C'est le bon mot de passe, le PC est accessible !");
                    TextMethods.RegularWriteLine("Il n'y a presque rien dessus, comme s'il avait été tout juste reformaté.");
                    TextMethods.RegularWriteLine("Seulement deux applications sont installées.");
                    TextMethods.RegularWriteLine("La première semble gérer des verrous magnétiques.");
                    TextMethods.RegularWriteLine("La seconde est un bloc-note.");
                    TextMethods.AttendreContinuer();

                    while (!porteOuverteSalle2)
                    {
                        Console.Clear();
                        TextMethods.RegularWriteLine("Que faire ?");
                        TextMethods.RegularWriteLine("1. Inspecter le gestionnaire de verrous   2. Lire le bloc-note");
                        string choixPC = Console.ReadLine();
                        while (choixPC != "1" && choixPC != "2" && choixPC != "3")
                        {
                            TextMethods.RegularWriteLine("Entrez une action possible.");
                            choixPC = Console.ReadLine();
                        }
                        Console.Clear();
                        switch (choixPC)
                        {
                            case "1":
                                TextMethods.RegularWriteLine("Réaliser une modification requiert un mot de passe");
                                TextMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour revenir en arrière");
                                string motDePasseVerrouMagnetique = Console.ReadLine();
                                if (motDePasseVerrouMagnetique == "2")
                                {
                                    break;
                                }

                                while (motDePasseVerrouMagnetique != "SESAME")
                                {
                                    Console.Clear();
                                    TextMethods.RegularWriteLine("Erreur ! Mot de passe incorrect !");
                                    TextMethods.RegularWriteLine("Entrez un mot de passe ou appuyer sur 2 pour revenir en arrière");
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
                                porteOuverteSalle2 = true;
                                finiAvecPC = true;
                                TextMethods.RegularWriteLine("Le mot de passe est correct !");
                                TextMethods.RegularWriteLine($"{heroName} tente d'ouvrir la porte de la salle.");
                                TextMethods.AttendreContinuer();
                                TextMethods.FastWriteLine("*CLACK*");
                                TextMethods.RegularWriteLine("La porte est dévérouillée !");
                                TextMethods.AttendreContinuer();
                                TextMethods.RegularWriteLine("Il n' y rien de plus à faire sur ce PC.");
                                TextMethods.AttendreContinuer();
                                break;

                            case "2":
                                Console.Clear();
                                TextMethods.RegularWriteLine($"{heroName} lit le bloc-note.");
                                TextMethods.AttendreContinuer();
                                TextMethods.FastWriteLine(
                                    "\"Select -w\n  les erreurs ne s'éffacEnt\n   elles s'accumulent tandis que les larmeS croissent\n    chaque action A sa conséquence\n     ton esprit a confirmé Mon existence\n       end codE\"");
                                TextMethods.AttendreContinuer();
                                break;
                        }
                    }
                    break;
                case "3":
                    TextMethods.RegularWriteLine("Au dos de l'écran se trouve un post-it.");
                    TextMethods.RegularWriteLine("Dessus est écrit quelque chose:");
                    TextMethods.AttendreContinuer();
                    TextMethods.RegularWriteLine("\"POUR QUE RITCHIE ARRETE D'OUBLIER :");
                    TextMethods.RegularWriteLine("Qu'est ce qui est jaune et qui attend ?\"");
                    TextMethods.AttendreContinuer();
                    break;
            }
        }




        while (dansSalle3)
        {
            Console.Clear();
            TextMethods.RegularWriteLine("Que faire ?");
            TextMethods.RegularWriteLine("1. Entrer dans les toilettes   2. Entrer dans le bureau de Layla     3. Parler à l'homme étrange");

            string choix3 = Console.ReadLine();
            while (choix3 != "1" && choix3 != "2" && choix3 != "3")
            {
                TextMethods.RegularWriteLine("Entrez une action possible.");
                choix3 = Console.ReadLine();
            }
            Console.Clear();
            switch (choix3)
            {
                case "1":
                    TextMethods.RegularWriteLine("A faire");
                    TextMethods.AttendreContinuer();
                    break;
                case "2":
                    if (!finiAvecSalle3)
                    {
                        TextMethods.RegularWriteLine("La porte est fermée.");
                        TextMethods.RegularWriteLine("Elle est bien trop solide pour être forcée ouverte");
                        TextMethods.RegularWriteLine("Il va falloir trouver une clé pour l'ouvrir.");
                        TextMethods.AttendreContinuer();
                        break;
                    }
                    break;
                case "3":
                    if (!finiAvecSalle3 && !parleAvecHommeFou)
                    {
                        parleAvecHommeFou = true;
                        TextMethods.RegularWriteLine($"{heroName} tente de parler à l'homme étrange.");
                        TextMethods.AttendreContinuer();
                        Console.ForegroundColor = ConsoleColor.Red;
                        TextMethods.SlowWriteLine("Ȉ̵̟͍͝l̷̲̹̕ ̷̻͉͊d̵͚̣̀o̴̙͈͌i̶̤͒ṭ̸͎̓ ̵̪́ề̵̪t̵̳͆r̷͔̞̐̽e̷͓̽ ̸͈͔̎p̷͔̤͆͐r̵̥̓̊͜ô̷̘̺c̷̹̓h̴̨̨͌è̸̼.̴͖̾");
                        TextMethods.SlowWriteLine("̵̩͌͂L̷̳͗̚͜e̶̡̓s̴͍̭̅͘ ̷̹͆e̵̙̳̒r̶̡̟̋͌r̴̪̈́͘ë̶̩̮̓u̷̮̥̓r̴̠͗͂s̵̰̎͝ ̵̡̈́a̷̛̳̞̓c̶̪̔ͅc̴̨̓͝ů̸̲̼m̷͎̓u̶̡̹͊͑l̶͔̄é̴̢͔̾e̵̱̟͆s̷̭̏͒.̶̼̆");
                        TextMethods.SlowWriteLine("̵̡̠̈Ĩ̴͈͔̈́l̴͉̟̿ ̶̺̑͋e̵̳̰̎s̵͖̀͜͠t̸̖̺̑̈ ̸͚͘c̵̙̅ờ̷͖m̷̢̞͂͑p̸̃ͅl̶̬̩͑̋ȩ̸̞̀̚ṭ̸̳̔̅.̷̤̂");
                        TextMethods.SlowWriteLine("̴̨͕̽̏C̶̹͂ͅ'̴̯̃̇ḙ̸̿͆n̸̤̉̓ ̵̺̜̍̄e̵̥̗̐͝s̵̺̫͆ţ̶̈ ̶̢̼͂f̵̯̑î̴̙͠n̶̻͆i̵̛̤ ̵̯̾̈d̵͈̄e̶̫͑̇ ̴̭̻̉ṉ̶̤̍̓o̴̭͌̃ͅu̵̺͈͛̎s̴̱̬͝.̵͓̭̌̀");
                        TextMethods.SlowWriteLine("̵̧̪͒̚I̷̼̤͂ĺ̸͍̳̐ ̶͎͙̾̾ḙ̵̫̌s̶͚̭͘t̶̙̬̓ ̶͙̏d̸̛̟̻̀é̶̻͛j̵̳͌̆à̴̩͛͌ ̴̖̂è̴͍̗n̴̡͋̈́ͅ ̷͍̈́c̷̢̃h̸͈͗â̷̤c̸͚̋̎u̶͍̿̃n̵̨͛̽ ̸̩̈̒d̵̬͝é̵̜͝ ̵̭̿̐n̷͍̰͂͘o̶͎͋ů̸̳̭͝s̶̙͓̅̔.̶̳̳̔");
                        TextMethods.SlowWriteLine("̴̡̋̓͜C̷̤̒̅h̸̜͂ä̸̢̬͆q̸̹̮͐̀u̶̫̟̓e̶̎͜͠ ̸̫̰̄c̸̫̺̆͝i̸̢̬͛̕r̵͇̅ç̶̺͛ü̷̹͙ȋ̸̦̒t̶͕̠͒̀ ̴̣͑̎ĕ̷͎s̴̰̚ṱ̶͑ ̸̧͓͋u̵̗̟͗n̷̘̰͆ ̴̟͗n̵̜̜͐ȏ̶̲͑u̵̮̎̏v̵̦͐̋e̵̮̅́ͅă̵̙̫͝ǘ̵̖̫ ̷̛͖r̸̻̠͆ê̵̲̫̆v̴͓̬̊͝ẻ̷̳͕̈ ̶̦͛̑d̷̞̙̀ę̷̛́̑v̸̻̓o̷̬͙͊̆i̸̥͂̅l̴̜̘̍͝é̷̞̠̓̚.̶͉̖̊̈́");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        TextMethods.AttendreContinuer();
                        TextMethods.RegularWriteLine("Impossible de tirer plus de lui ...");
                        TextMethods.AttendreContinuer();
                        break;
                    }
                    else
                    {
                        TextMethods.RegularWriteLine($"{heroName} tente de parler à l'homme étrange.");
                        TextMethods.RegularWriteLine("Impossible de tirer plus de lui ...");

                    }


                    break;
            }
        }
    }
}