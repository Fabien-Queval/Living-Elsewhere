# Living Elsewhere

## Présentation

Living Elsewhere est un jeu de rôle intégrant des composantes de life sim et de dating sim.

Son ambition est de rendre le monde vivant et indépendant du joueur, afin que celui-ci puisse faire ce dont il a envie tout en influençant, de différentes manières, le cours des événements.

## État actuel

### Sprint 1 - Complété

### Adventurer :
Un aventurier est décrit, et affiché.
La propriété `Level` est lisible depuis l’extérieur, mais seul `Adventurer` peut la modifier grâce à `private set`. La méthode publique `LevelUp()` augmente le niveau de l’instance sur laquelle elle est appelée.

### Quest: 
Une quête est pour l'instant décrite et affichée, pas encore résolue


## Lancer le prototype

Depuis le dossier racine du projet, exécuter :

`dotnet run --project LivingElsewhere.Console`