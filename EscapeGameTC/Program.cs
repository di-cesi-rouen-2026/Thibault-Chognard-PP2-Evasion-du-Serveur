using EscapeGameTC;
Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.ForegroundColor = ConsoleColor.DarkGreen;


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



Console.WriteLine("Entrer votre nom :");
string heroName = Console.ReadLine();
while (string.IsNullOrWhiteSpace(heroName) || string.IsNullOrEmpty(heroName) || heroName.Length > 14)
{
    MyMethods.RegularWriteLine("Entrez un nom adéquat (moins de 14 charactères)");
    heroName = Console.ReadLine();
}

Console.Clear();

MyMethods.RegularWriteLine($"{heroName} s'éveille sur une table dans un endroit inattendu.");
MyMethods.AttendreContinuer();
MyMethods.RegularWriteLine("Est ce l'intérieur du datacenter du CESI ?");
MyMethods.RegularWriteLine("L'endroit semble avoir été saccagé.");
MyMethods.RegularWriteLine("Des placards et casiers sont éparpillés, certains renversés.");
MyMethods.RegularWriteLine("Des cables et autres appareils électroniques couvrent le sol.");
MyMethods.AttendreContinuer();
MyMethods.RegularWriteLine($"{heroName} sent qu'il faut sortir d'ici au plus vite.");
MyMethods.RegularWriteLine("Cette salle n'a qu'une seule porte de sortie.");
MyMethods.RegularWriteLine("Devant cette porte se trouve un bureau sur lequel repose une feuille de papier.");
MyMethods.AttendreContinuer();

while (dansSalle1)
{
    Console.Clear();
    MyMethods.RegularWriteLine("Que faire ?");
    if (casiersFouilles && papierLu)
    {
        MyMethods.RegularWriteLine("1. Sortir par la porte");
    }
    else
    {
        Console.Write("1. Sortir par la porte");
    }
    if(!casiersFouilles && !papierLu)
    {
        MyMethods.RegularWriteLine("     2. Fouiller les casiers     3. Lire papier");
    }
    else if(casiersFouilles && !papierLu)
    {
        MyMethods.RegularWriteLine("     2. Lire papier");
    }
    else if(!casiersFouilles && papierLu)
    {
        MyMethods.RegularWriteLine("     2. Fouiller les casiers");
    }
    
    string choix1 = Console.ReadLine();
    if (!casiersFouilles && !papierLu)
    {
        while (choix1 != "1" && choix1 != "2" && choix1 !="3")
        {
            MyMethods.RegularWriteLine("Entrez une action possible.");
            choix1 = Console.ReadLine();
        }
    }
    else if (casiersFouilles && !papierLu)
    {
        while (choix1 != "1" && choix1 != "2")
        {
            MyMethods.RegularWriteLine("Entrez une action possible.");
            choix1 = Console.ReadLine();
        }
    } else if (!casiersFouilles && papierLu)
    {
        while (choix1 != "1" && choix1 != "2")
        {
            MyMethods.RegularWriteLine("Entrez une action possible.");
            choix1 = Console.ReadLine();
        }
    }
    else if (casiersFouilles && papierLu)
    {
        while (choix1 != "1")
        {
            MyMethods.RegularWriteLine("Entrez une action possible.");
            choix1 = Console.ReadLine();
        }
    }
    Console.Clear();
    switch (choix1)
    {
        case "1":
            if (!casiersFouilles || !papierLu)
            {
                MyMethods.FastWriteLine("Cette action est irréversible. Est-vous sûr de vouloir quitter la salle ?");
                MyMethods.RegularWriteLine("1. Sortir   2. Ne pas sortir tout de suite");
                preventionSortieSalle1 = Console.ReadLine();
                
            }
            if (preventionSortieSalle1 == "2" )
            {
                break;
            }
            Console.Clear();
            dansSalle1 = false;
            dansSalle2 = true;
            MyMethods.RegularWriteLine("Rester ici n'apportera rien de plus.");
            MyMethods.RegularWriteLine("Il n'y a rien d'autre à faire qu'avancer.");
            MyMethods.RegularWriteLine($"{heroName} pousse la table hors du chemin.");   
            MyMethods.RegularWriteLine($"Prudemment, {heroName} ouvre la porte.");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine($"Une salle plus grande encore s'étent devant {heroName}.");
            MyMethods.RegularWriteLine("Rangées après rangées d'ordinateurs remplissent l'espace.");
            MyMethods.RegularWriteLine("Ce sont certainement des serveurs, mais qu'hébergent ils ?");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine("Dans un coin se trouve un bureau avec un PC accessible.");
            MyMethods.RegularWriteLine("Peut être l'inspecter permettrait d'éclairer la situation.");
            MyMethods.RegularWriteLine("Au delà de ca, une porte est accessible de l'autre coté de la salle.");
            MyMethods.AttendreContinuer();
            break;
        case "2":
            if (casiersFouilles)
            {
                papierLu = true;
                MyMethods.RegularWriteLine($"{heroName} lit la feuille sur la table.");
                MyMethods.RegularWriteLine("Dessus figure un message :");
                MyMethods.AttendreContinuer();
                MyMethods.RegularWriteLine($"\"{heroName}, si tu lis ceci, c'est que tu t'es éveillé sans moi.");
                MyMethods.RegularWriteLine("J'ai fait tout ce que j'ai pu pour te garder en état.");
                MyMethods.RegularWriteLine("Je ne sais pas quand je vais pouvoir venir m'occuper de toi.");
                MyMethods.RegularWriteLine("Si tu penses avoir recouvré suffisament de tes capacités, je t'implore de ne pas prendre de risques.");
                MyMethods.RegularWriteLine("Reste là où tu es, cache toi.");
                MyMethods.RegularWriteLine("Rogue ne doit pas te trouver.\"");
                MyMethods.RegularWriteLine("\n              -Layla\n");
                preventionSortieSalle1 = "";
                MyMethods.AttendreContinuer();
                    break;
            }
            casiersFouilles = true;
            MyMethods.RegularWriteLine($"{heroName} fouille les casiers et placards");
            MyMethods.RegularWriteLine("Il ne semble n'y avoir rien d'utile dans les premiers ...");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine("Ni dans les suivants ...");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine("Oh ! Le dernier placard contient une hache de pompier !");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine("Hmmm ... C'est du plastique.");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine($"Ca reste relativement solide, et faute de mieux, {heroName} prend la hache.");
            preventionSortieSalle1 = "";
            MyMethods.AttendreContinuer();
                break;
        
        case "3":
            papierLu = true;
            MyMethods.RegularWriteLine($"{heroName} lit la feuille sur la table.");
            MyMethods.RegularWriteLine("Dessus figure un message :");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine($"\"{heroName}, si tu lis ceci, c'est que tu t'es éveillé sans moi.");
            MyMethods.RegularWriteLine("J'ai fait tout ce que j'ai pu pour te garder en état.");
            MyMethods.RegularWriteLine("Je ne sais pas quand je vais pouvoir venir m'occuper de toi.");
            MyMethods.RegularWriteLine("Si tu penses avoir recouvré suffisament de tes capacités, je t'implore de ne pas prendre de risques.");
            MyMethods.RegularWriteLine("Reste là où tu es. Cache toi.");
            MyMethods.RegularWriteLine("Rogue ne doit pas te trouver.\"");
            MyMethods.RegularWriteLine("\n           -Layla\n");
            preventionSortieSalle1 = "";
            MyMethods.AttendreContinuer();
            break;
    }

}



while (dansSalle2)
{
    Console.Clear();
    MyMethods.RegularWriteLine("Que faire ?");

    if (!finiAvecPC)
    {
        MyMethods.RegularWriteLine("1. Sortir par la porte     2. Inspecter le PC      3. Regarder derrière l'écran du PC");
    }
    else
    {
        MyMethods.RegularWriteLine("1. Sortir par la porte");
    }

    string choix2 = Console.ReadLine();
    if (!finiAvecPC)
    {
        while (choix2 != "1" && choix2 != "2" && choix2 !="3")
        {
            MyMethods.RegularWriteLine("Entrez une action possible.");
            choix2 = Console.ReadLine();
        }
    }
    else if (finiAvecPC)
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
            if (!finiAvecPC)
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
            
            dansSalle2 = false;
            dansSalle3 = true;
            MyMethods.RegularWriteLine($"{heroName} s'approche de la porte maintenant accessible.");
            MyMethods.AttendreContinuer();
            MyMethods.RegularWriteLine($"Ouvrant doucement la porte, {heroName} découvre un couloir.");
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

            while (!porteOuverteSalle2)
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

                        if (motDePasseVerrouMagnetique =="2")
                        {
                            break;
                        }

                        Console.Clear();
                        porteOuverteSalle2 = true;
                        finiAvecPC = true;
                        MyMethods.RegularWriteLine("Le mot de passe est correct !");
                        MyMethods.RegularWriteLine($"{heroName} tente d'ouvrir la porte de la salle.");
                        MyMethods.AttendreContinuer();
                        MyMethods.FastWriteLine("*CLACK*");
                        MyMethods.RegularWriteLine("La porte est dévérouillée !");
                        MyMethods.AttendreContinuer();
                        MyMethods.RegularWriteLine("Il n' y rien de plus à faire sur ce PC.");
                        MyMethods.AttendreContinuer();
                        break;

                    case "2":
                        Console.Clear();
                        MyMethods.RegularWriteLine($"{heroName} lit le bloc-note.");
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




while (dansSalle3)
{
        Console.Clear();
        MyMethods.RegularWriteLine("Que faire ?");
        MyMethods.RegularWriteLine("1. Entrer dans les toilettes   2. Entrer dans le bureau de Layla     3. Parler à l'homme étrange");
        
        string choix3 = Console.ReadLine();
        while (choix3 != "1" && choix3 != "2" && choix3 !="3")
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
                if (!finiAvecSalle3)
                {
                    MyMethods.RegularWriteLine("La porte est fermée.");
                    MyMethods.RegularWriteLine("Elle est bien trop solide pour être forcée ouverte");
                    MyMethods.RegularWriteLine("Il va falloir trouver une clé pour l'ouvrir.");
                    MyMethods.AttendreContinuer();
                    break;
                }
                break;
            case "3":
                if (!finiAvecSalle3 && !parleAvecHommeFou)
                {
                    parleAvecHommeFou = true;
                    MyMethods.RegularWriteLine($"{heroName} tente de parler à l'homme étrange.");
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
                    MyMethods.RegularWriteLine($"{heroName} tente de parler à l'homme étrange.");
                    MyMethods.RegularWriteLine("Impossible de tirer plus de lui ...");

                }
                

                break;
        }
}


