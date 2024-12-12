# Khrnam Tower Defense

Projet dans le cadre du cours de méthodologie avancée, KHRNAM-TD est un jeu développé sur le framework Unity (C#). Le but de l'exercice étant de construire le jeu à l'aide des différents patrons de conceptions vu en cours.  
[Voir le détail ici sur les patrons de conception (design pattern) existant](https://refactoring.guru/design-patterns)  

# Design Pattern identifiés pour ce projet

| Design Pattern | Utilisation                                |
|:--------------:|:------------------------------------------:|
| Factory        | Création des tours                         |
| Factory        | Création des enemies                       |
| Singleton      | Managers dans le code                      |
| Decorator      | Gestion du type de tour                    |
| Decorator      | Gestion du type de enemie                  |
| Strategy       | Récupération des debuff sur les enemies    |
| Command        | Pose des tours                             |
| Command        | Ouverture des menu, interactions ?         |
| Prototype      | Gérer les multiples enemies dans une vague |

# Diagramme de classe

Voir ici le diagramme de classe récapitulant le fonctionnement et la structure du code :  
https://drive.google.com/file/d/1H8_9zLFdlGgAXW9IdWxSzTzOEMuvTpRB/view?usp=sharing  

# Organisation du repository

- KHRNAM-TD : Dossier contenant le code source du projet
- docs : Dossier contenant les éléments documentant le projet (diagrammes, pdf, etc.)
- .gitignore
- README.md
