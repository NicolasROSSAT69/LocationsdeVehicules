# LocationsdeVehicules
Projet BDD M1 AL 

## Sujet :
Votre équipe de développement vient de se voir commandé le développement d’une API permettant de gérer une centrale de réservation de véhicule.
Le Product Owner (PO) de l’équipe a déjà réalisé le recueil des besoins et défini les différentes règles métiers.
Règles métiers :
Cas d’utilisation :
• Le client s’identifie ou créer un compte
• Le client rentre la date de début et la date de fin de la location qu’il
souhaite effectuer
• La liste des véhicules disponibles est présentée au client
• Le client sélectionne une voiture parmi la liste fournie
• La réservation est créée
• Lorsque le client rend la voiture, la facture avec le prix final est générée
Description des objets :
Véhicule
• Un véhicule est représenté par une immatriculation unique
• Il possède une marque, un modèle et une couleur
• Un véhicule dispose d’un prix de réservation qui permet de couvrir les
frais de dossier et le nettoyage du véhicule
• Il dispose également d’un tarif kilométrique permettant de couvrir
l’usure du véhicule
• Un nombre de chevaux fiscaux
Client
• Un client est défini par nom, un prénom
• Il est important de pouvoir de posséder la date de naissance du client
ainsi que la date d’obtention de son permis de conduire pour savoir quel
sera le prix de l’assurance
• Le numéro de permis du client est enregistré afin de pouvoir être fournis
aux autorités si un problème devait survenir.
   
Réservation
• Une réservation est une association entre un client et un véhicule
• Une réservation a toujours une date de début et une date de fin
• Un client ne peut réserver qu’un seul véhicule à la fois
• Le véhicule souhaité par le client doit être disponible entre la date de
début et la date de fin
• Un client doit au moins avoir 18 ans et posséder le permis de conduire
pour réserver un véhicule
• Un conducteur de moins de 21 ans ne peut pas louer un véhicule
possédant 8 chevaux fiscaux ou plus
• Un conducteur entre 21 et 25 ans ne peut louer que des véhicules de
moins de 13 chevaux fiscaux.
• Lors de la réservation, le client doit estimer le nombre de km qu’il
compte faire. Le prix de location est calculé en fonction de cette estimation. Bien entendu si cette estimation est dépassée ou surestimé un réajustement est effectué lors du rendu de véhicule
• Le prix d’une location est le suivant : prix de base + prix au km * nb de km
