# Thibault-Chognard-PP2-Evasion-du-Serveur

Projet Personnel 2 : Evasion du serveur Projet DI26



Thème des salles =

&#x09;1.Algorithmie

&#x09;2.Musique

&#x09;3.Faune et flore

&#x09;4.Anglais

&#x09;5.Informatique







SQLite Query pour insérer jeu de donnée =



@"INSERT OR IGNORE INTO Salle (Nom\_Salle) VALUES ('Bureau'), ('Salle de repos'), ('Cour intérieure'), ('Couloir'), ('Salle des serveurs');



INSERT OR IGNORE INTO Enigmes (Question, Reponse\_Correcte, Reponse\_Fausse\_1, Reponse\_Fausse\_2, ID\_Salle) Values

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

('Quel est le numéro du premier indice d''un tableau', '0', '1', 'Les tableaux n''ont pas d''indices', 1);"



