Feature: Location

Background: 
	Given client existant
	| Username | Password  | Nom    | Prenom  | DatePermis | NumeroPermis |
	| nrossat  | coolraoul | ROSSAT | Nicolas | 2018-04-20 | 4294967296   |
	| jrocher  | banane    | ROCHER | Jesus   | 2018-07-25 | 4287967223   |
 
	Given vehicule existant
	  | Immatriculation | Marque  | Modele     | Couleur | TarifKilometrique | PrixReservation | ChevauxFiscaux |
	  | AA-353-AB       | Renaut  | Modus      | Blanc   | 3                 | 45              | 3              |
	  | AA-456-AC       | Renaut  | Senic      | Noir    | 5                 | 55              | 5              |
	  | AA-676-AD       | Dacia   | Duster     | Rouge   | 4                 | 50              | 4              |
	  | AA-777-AE       | Ferrari | 458 Spider | Jaune   | 10                | 80              | 8              |
	  | AA-666-AE       | Bugatti | Chiron     | Bleu    | 20                | 110             | 214            |
   
	Given réservations existantes
	  | Client  | Vehicule  | DateDebut  | DateFin    |
	  | jrocher | AA-353-AB | 2022-02-11 | 2022-02-18 |

Scenario: Connexion client - Utilisateur reconnu 
	Given mon nom est "nrossat"
	And mon mot de passe est "coolraoul"
	When j'essaye de me connecter à mon compte
	Then la connexion est établie
	
Scenario: Connexion client - Utilisateur non reconnu 
	Given mon nom est "nrossat"
	And mon mot de passe est "chocolat"
	When j'essaye de me connecter à mon compte
	Then la connexion n'est pas établie
	
Scenario: Fournir liste voiture dispo - Toutes les voiture sont dispo
	Given la date de debut de la reservation du client est "2022-03-11"
	Given la date de fin de la reservation du client est "2022-03-18"
	When la liste des voitures dispos est fournit au client
	Then la liste est "Modus: AA-353-AB, Senic: AA-456-AC, Duster: AA-676-AD"
	
Scenario: Fournir liste voiture dispo - Toutes les voiture ne sont pas dispo
	Given la date de debut de la reservation du client est "2022-02-11"
	Given la date de fin de la reservation du client est "2022-02-18"
	When la liste des voitures dispos est fournit au client
	Then la liste est "Senic: AA-456-AC, Duster: AA-676-AD"
	
Scenario: Créer réservation - Utilisateur connecté 
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-456-AC"
	When je fais la reservation
	Then la reservation est faite
	
Scenario: Créer réservation - Utilisateur non connecté 
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And utilisateur pas connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-456-AC"
	When je fais la reservation
	Then la reservation n'est pas faite
	
Scenario: Créer réservation - Véhicule choisit déjà reservé
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-02-11"
	And la date de fin de location est "2022-02-18"
	And le véhicule choisi est "AA-353-AB"
	When je fais la reservation
	Then la reservation n'est pas faite
	
Scenario: Créer réservation - Le client a déjà une reservation
	Given le nom de l'utilisateur est "jrocher"
	And La date de naissance de l'utilisateur est "2000-06-22"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-456-AC"
	When je fais la reservation
	Then la reservation n'est pas faite
	
Scenario: Créer réservation - Utilisateur a plus de 18 ans 
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-456-AC"
	When je fais la reservation
	Then la reservation est faite
	
Scenario: Créer réservation - Utilisateur a moins de 18 ans 
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2006-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-456-AC"
	When je fais la reservation
	Then la reservation n'est pas faite
	
Scenario: Créer réservation - Utilisateur a moins de 21 ans et choisit une voiture de plus de 8 chevaux fiscaux
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2002-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-777-AE"
	When je fais la reservation
	Then la reservation n'est pas faite
	
Scenario: Créer réservation - Utilisateur a plus de 21 ans et choisit une voiture de plus de 8 chevaux fiscaux
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-777-AE"
	When je fais la reservation
	Then la reservation est faite
	
Scenario: Créer réservation - Utilisateur a entre 21 ans et 25 et choisit une voiture de plus de 13 chevaux fiscaux
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-666-AE"
	When je fais la reservation
	Then la reservation n'est pas faite

Scenario: Créer réservation - Utilisateur a entre 21 ans et 25 et choisit une voiture de moins de 13 chevaux fiscaux
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "2000-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-777-AE"
	When je fais la reservation
	Then la reservation est faite
	
Scenario: Créer réservation - Utilisateur a plus de 25 ans et choisit une voiture de plus de 13 chevaux fiscaux
	Given le nom de l'utilisateur est "nrossat"
	And La date de naissance de l'utilisateur est "1994-04-20"
	And l'utilisateur est connecté
	And la date de début de location est "2022-03-11"
	And la date de fin de location est "2022-03-18"
	And le véhicule choisi est "AA-666-AE"
	When je fais la reservation
	Then la reservation est faite

Scenario: Calculer prix location - Location cloturée
	Given la location est au nom de "jrocher"
	And la location est terminé
	And le nombre de kilomètre parcouru est 17
	When J'essaye de calculer la location
	Then le prix de la location est "96"
	
Scenario: Calculer prix location - Location n'est pas cloturée
	Given la location est au nom de "jrocher"
	And la location n'est pas terminé
	And le nombre de kilomètre parcouru est 17
	When J'essaye de calculer la location
	Then le prix de la location est "La Location n'est pas fini"
	
Scenario: Calculer prix location - Location n'existe pas
	Given la location est au nom de "nrossat"
	And la location n'est pas terminé
	And le nombre de kilomètre parcouru est 17
	When J'essaye de calculer la location
	Then le prix de la location est "La location n'existe pas"