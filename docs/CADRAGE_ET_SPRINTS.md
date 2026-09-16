# Simulateur de guilde — stack et parcours de réalisation

Version de travail du 8 septembre 2026. Proposition initiale, à ajuster avec Fabien après les premières revues.

## 1. Objectif et point de départ

Créer un jeu de gestion de guilde dans lequel le vécu des aventuriers influence leurs aventures suivantes. Le projet doit aussi permettre à Fabien d'apprendre C#, Godot et Docker et de constituer une démonstration de ses compétences pour une éventuelle orientation vers le jeu vidéo.

Fabien déclare une expérience de l'écosystème web, notamment Java, Spring/Spring Boot, JavaScript/TypeScript, Angular, PHP/Symfony, HTML/CSS, SQL, bases relationnelles, Git/GitHub, API REST, modélisation et tests. La profondeur de chaque acquis sera vérifiée par de petits exercices, sans reprendre automatiquement toute la programmation depuis zéro. C#, Godot et Docker sont nouveaux.

L'apprentissage fait partie du travail planifié : cours, exercices, installation, configuration, recherche d'erreurs et revue comptent dans le temps du sprint.

## 2. Stack proposée

| Élément | Choix | Introduction et utilité |
|---|---|---|
| Cible initiale | Jeu solo local pour Windows, interface 2D | Démo téléchargeable ; périmètre initial à confirmer avec Fabien |
| Langage et plateforme | C# avec SDK .NET 10 LTS | Sprint 0 ; simulation console, puis bibliothèque réutilisée par Godot |
| Éditeur | JetBrains Rider | Choix retenu après le téléchargement signalé par Fabien ; installation et configuration à vérifier au sprint 0 |
| Dépendances | NuGet, outil de l'écosystème .NET | Lors de l'introduction du premier outil de test ; expliquer avant usage |
| Versionnement et suivi | Git, GitHub, tickets et tableau simple | Sprint 0 ; un seul dépôt, décisions et progression visibles |
| Tests métier | xUnit.net v3 | Sprint 3 ; vérifier les conséquences des mémoires et les cas limites |
| Conteneurs | Docker Desktop, moteur WSL 2, conteneurs Linux | Sprint 4 ; exécuter la console et les tests de façon reproductible |
| Sauvegarde | JSON avec System.Text.Json | Sprint 5 ; conserver une aventure sans serveur de base de données |
| Interface du jeu | Godot 4, édition .NET, version stable | Sprint 6 ; point de départ relevé : 4.7.2, à revérifier lors de l'installation |
| Vérifications automatiques | GitHub Actions | Sprint 9 ; compilation et tests du moteur sur le dépôt |
| Documentation | Markdown, croquis et UML léger si utile | Dès le début ; installation, règles de jeu, décisions et bilans |

.NET 10 est soutenu jusqu'au 14 novembre 2028 selon la [politique Microsoft](https://dotnet.microsoft.com/en-us/platform/support/policy). Utiliser un correctif stable récent, puis noter et fixer le SDK retenu dans le dépôt après explication de son fichier de configuration.

La [page officielle Godot pour Windows](https://godotengine.org/download/windows/) présente actuellement Godot 4.7.2 et une édition .NET distincte. Le SDK .NET doit être installé séparément. La [documentation C# de Godot](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_basics.html) précise que les projets Godot 4 en C# ne peuvent actuellement pas être exportés vers le web. La vitrine initiale sera donc un exécutable Windows accompagné de captures ou d'une courte vidéo.

Le SDK installé, le framework ciblé par chaque projet et la version de Godot sont trois réglages distincts. Au sprint 6, vérifier la compilation et l'export d'un petit projet C# qui référence le moteur avant de construire l'interface complète. Aligner les frameworks des projets sur une combinaison réellement vérifiée ; ne pas supposer qu'un projet généré par Godot cible automatiquement .NET 10.

La [documentation C# de Godot, section JetBrains Rider](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_basics.html#jetbrains-rider) servira pour relier Godot à Rider au sprint 6. La [documentation xUnit](https://xunit.net/docs/getting-started/v3/getting-started) servira pour choisir les paquets compatibles au sprint 3.

Docker sera un apprentissage appliqué au projet : la console et les tests tourneront en conteneur ; l'éditeur Godot et le jeu graphique resteront des applications locales. La [documentation Docker pour Windows](https://docs.docker.com/desktop/setup/install/windows-install/) servira à vérifier Windows, WSL 2 et la virtualisation avant l'installation. Le [guide .NET de Docker](https://docs.docker.com/guides/dotnet/) complète le cours, en adaptant ses exemples à notre application console.

Les prérequis matériels et logiciels de ce PC n'ont pas encore été audités. Les installations seront réalisées avec Fabien dans les sprints concernés.

## 3. Architecture progressive

Commencer par une application console simple. Extraire le moteur en bibliothèque au moment où les tests doivent l'appeler directement. L'organisation visée devient alors :

```text
Console ────────┐
Tests ──────────┼──> Moteur de simulation C# pur
Godot, ensuite ─┘
```

Le moteur ne dépend ni de Godot, ni de l'affichage console. Godot reçoit les actions du joueur, appelle le moteur et affiche ses résultats. Les règles de quête et de mémoire restent dans le moteur.

Introduire les classes au fil du besoin : Adventurer et Quest, puis Memory et QuestResult ; Party et les événements plus variés ensuite. Pas d'obligation de créer tout ce modèle dès le premier exercice. Éviter le nom générique Event si un nom métier tel que QuestEvent décrit mieux l'objet.

Un service apparaît quand une responsabilité réelle doit être isolée. Une méthode de résolution simple suffit au départ. CombatService apparaîtra si le combat devient un système autonome ; QuestResolutionService pourra alors l'appeler.

Pour la première démonstration, la résolution peut être déterministe. Une valeur de difficulté et une règle explicite rendent l'effet d'un souvenir observable. Introduire le hasard seulement après un cours sur les probabilités et sur la manière de tester une résolution sans tests instables.

Le LLM reste une extension ultérieure. Le C# établit les faits. Les textes générés doivent respecter ces faits ; les propositions de nouveaux effets doivent passer une validation métier explicite avant toute modification de l'état du jeu.

## 4. Organisation pédagogique

Disponibilité confirmée par Fabien : 5 à 7 heures par semaine, cours et revue compris. Ce n'est pas un engagement de date de livraison. Si les difficultés imposent moins de travail, découper un objectif sur plusieurs sprints hebdomadaires. Les étapes ci-dessous forment un ordre de progression, pas une promesse de livraison en onze semaines.

Répartition indicative d'un sprint : 25 % cours et exercice, 50 % réalisation, 25 % vérification, revue et corrections. Un seul objectif principal à la fois. Une installation bloquante prend la place d'une fonctionnalité ; elle ne s'ajoute pas à la charge prévue.

Avant chaque notion nouvelle : expliquer son utilité dans le sprint, montrer un petit exemple extérieur au jeu, faire réaliser un exercice, puis appliquer au projet. S'appuyer sur Java ou TypeScript quand la comparaison aide et signaler les différences plutôt que promettre une équivalence exacte.

Fabien réalise le code. L'assistant d'atelier 5.6 donne les cours, aide à déboguer et propose des indices progressifs. Une correction ciblée reste possible ; la compréhension est vérifiée par une explication ou une petite variante réalisée par Fabien. Éviter de livrer d'emblée toute la solution du sprint.

Zia-Astra prépare le périmètre et les critères, puis réalise la revue de fin de sprint sur les fichiers et résultats effectivement fournis. La revue précise ce qui a été exécuté et ce qui a seulement été lu.

## 5. Parcours des sprints

| Étape | Prélude de cours | Travail prévu | Preuve de réussite |
|---|---|---|---|
| S0 — Poste de travail | C# / .NET / SDK / runtime ; projet et compilation ; débogueur ; fichiers générés et Git | Installer ou vérifier .NET et l'éditeur, configurer le débogage, préparer le dépôt et le guide de lancement | Un programme console démarre ; un point d'arrêt fonctionne ; Fabien explique chaque outil et relance depuis le guide |
| S1 — Premier aventurier | Syntaxe C# utile, types, méthodes, classes, propriétés, constructeurs, visibilité ; différences avec Java | Modéliser et afficher un aventurier et une quête ; écrire une première méthode simple | Deux instances peuvent être créées indépendamment ; Fabien modifie une propriété et explique le chemin d'exécution |
| S2 — V0 microscopique | Enums, List<T>, composition d'objets, boucles et conditions selon les besoins | Résoudre une quête comportant un piège ; produire un résultat et ajouter une mémoire structurée | Une exécution montre aventurier, quête, résultat et mémoire consultable ; le souvenir contient des données utilisables, pas seulement une phrase |
| S3 — Le vécu change la suite | Références entre projets, bibliothèque C#, NuGet, xUnit, assertions et cas limites | Extraire le moteur, appliquer l'effet d'une mémoire pertinente et écrire les tests métier | À situation égale, une mémoire pertinente change le calcul ; une mémoire sans rapport ne le change pas ; une règle cassée fait échouer un test |
| S4 — Docker utile | Image / conteneur, Linux via WSL 2, Dockerfile, contexte de construction, étapes SDK/runtime et codes de sortie | Vérifier les prérequis, installer/configurer Docker, conteneuriser la console et les tests | Une image reconstruite exécute le scénario ; la commande de tests renvoie un échec lorsqu'un test échoue ; Fabien explique le Dockerfile |
| S5 — Une histoire persistante | Sérialisation JSON, fichiers et chemins, valeurs nulles, exceptions ; volumes Docker avant usage | Sauvegarder puis recharger aventurier et mémoires ; définir le comportement en absence de sauvegarde | Après fermeture et relance, le souvenir conserve son effet ; fichier absent ou invalide traité de façon compréhensible ; démonstration de persistance via volume |
| S6 — Prise en main de Godot | Scènes, nœuds, cycle de vie, scripts C#, héritage/override/partial nécessaires ; contrôles, conteneurs et signaux | Installer l'édition .NET et les modèles d'export correspondants ; configurer l'éditeur ; tester le lien avec le moteur et un export Windows minimal | Un bouton C# déclenche une action simple du moteur dans l'éditeur et dans l'export ; aucune règle métier n'est recopiée dans l'interface |
| S7 — La V0 devient jouable | Flux entre interface et moteur, événements C# utiles, état d'interface et prévention des doubles actions | Afficher aventurier, quête, résultat et souvenirs ; lancer la mission depuis un bouton | Le joueur voit un souvenir apparaître puis influencer une situation suivante ; une action ne résout pas deux fois une mission |
| S8 — Une petite guilde | Collections et identifiants ; règles de groupe ; recherche simple, LINQ seulement si nécessaire et expliqué | Ajouter quelques aventuriers, un petit choix de quêtes et la composition d'un groupe | Une sélection invalide est refusée ; les conséquences et mémoires sont attribuées aux bons aventuriers ; scénario court complet |
| S9 — Démo de portfolio | Export de livraison, tests de parcours, lisibilité d'interface ; intégration continue et YAML avant configuration | Préparer une démo Windows, automatiser compilation/tests du moteur, rédiger le README et expliquer les choix, ajouter captures et crédits d'assets | Une autre personne peut lancer la démo sans SDK ni Docker ; le dépôt explique la mécanique centrale et permet de reproduire les vérifications |

S1 et S2 conduisent à la V0 promise : un aventurier, une quête, une résolution, une mémoire. S3 valide la singularité du jeu. S7 en fait une première démonstration graphique. Le périmètre S8 reste volontairement réduit ; relations complexes, combats détaillés et économie complète vont au backlog.

Les sprints S4, S6 et S8 peuvent nécessiter un découpage supplémentaire. Seul le sprint prochain sera détaillé et engagé après la revue du précédent.

## 6. Fiche initiale du sprint 0

**Objectif :** Fabien sait créer, lancer et déboguer une application console C# avec un environnement dont il comprend les composants.

**Charge proposée :** 4 à 6 heures, dans l'enveloppe confirmée de 5 à 7 heures hebdomadaires ; conserver une marge pour les difficultés d'installation.

### Cours et exercice — environ 1 heure

- Situer C#, .NET, SDK et runtime ; faire le rapprochement avec les outils Java déjà connus.
- Comprendre le rôle d'un fichier .cs et d'un fichier .csproj, puis la différence entre restaurer les dépendances, compiler et exécuter.
- Expliquer les quelques lignes du modèle console, y compris ses instructions de niveau supérieur si le modèle en utilise.
- Comprendre point d'arrêt, pas à pas et inspection d'une variable.

### Réalisation — environ 2 à 3 heures

- S0-01 : relever les outils déjà installés et l'architecture du PC ; vérifier l'installation de JetBrains Rider, dont Fabien a signalé le téléchargement.
- S0-02 : installer ou vérifier le SDK .NET retenu, configurer Rider pour l'utiliser et vérifier le débogage ; noter les versions.
- S0-03 : créer une application console de découverte et la lancer depuis le terminal et l'éditeur.
- S0-04 : modifier un message, observer une variable au débogueur, provoquer puis corriger une petite erreur de compilation après explication.
- S0-05 : préparer Git, un fichier d'exclusion adapté et un README expliquant le lancement. Introduire chaque fichier de configuration avant de l'ajouter. Le choix du nom et de la visibilité GitHub accompagne la création du dépôt distant.

### Revue et correction — environ 1 à 2 heures

- Reproduire le lancement à partir du README.
- Vérifier que le code source et la configuration utile sont versionnés, que les sorties générées ne le sont pas.
- Montrer un point d'arrêt et expliquer la valeur observée.
- Expliquer avec ses mots ce qui compile le programme et ce qui l'exécute.
- Noter un acquis, une difficulté et la correction apportée.

**Hors de ce sprint :** implémentation du jeu, installation Godot et Docker. Ces outils disposent de leur propre temps d'apprentissage dans le parcours.

## 7. Définition de terminé et revue

Un sprint est terminé quand son comportement attendu est démontré, que les vérifications pertinentes passent, que le guide concerné est à jour et que Fabien peut expliquer les éléments ajoutés. Une capture seule ne prouve pas que les règles sont correctes.

À apporter en revue : référence du commit ou fichiers concernés, procédure de démonstration, résultats des tests quand ils existent, difficultés rencontrées et notions encore floues. Aucun pourcentage de couverture arbitraire : tester en priorité les règles métier et les régressions plausibles.

La revue couvre le fonctionnement, la compréhension, la simplicité du code, l'indépendance du moteur et la valeur pour le joueur. Résultat : validé, ou corrections nécessaires clairement listées. Les améliorations facultatives rejoignent le backlog. Un blocage métier ou un objectif pédagogique non acquis est repris avant de dépendre de cet acquis dans la suite.

## 8. Extensions après la première démo

- Narration LLM : cours sur appels HTTP en C#, async/await, contrats JSON, validation métier, délais et erreurs. Première expérience avec une réponse simulée, puis appel réel si retenu. Le jeu conserve un récit de secours et reste jouable sans réseau. Une démo distribuée ne doit pas embarquer une clé API privée ; décider du mode d'accès avant de la distribuer.
- Synthèse biographique : séparer les faits structurés de leur résumé narratif et vérifier qu'une synthèse ne supprime pas une information nécessaire au moteur.
- SQLite : l'introduire si les requêtes ou la taille des sauvegardes justifient le passage à une base ; apprendre alors accès aux données et migrations.
- Combat, blessures durables, relations et économie : une mécanique à la fois, chacune avec ses règles et ses preuves de fonctionnement.
- Direction artistique : garder les croquis et compositions de Fabien ; prototyper l'interface avec des éléments simples avant la finition.

Le périmètre initial ne prévoit pas de serveur, API REST, Spring, Angular, ORM, microservices, Docker Compose ou Kubernetes. Leur présence éventuelle devra répondre à un besoin concret. La priorité portfolio reste une simulation intéressante, jouable et expliquée.

## 9. Consigne de passage à l'atelier

Transmettre ce document et la fiche du sprint actif à 5.6. Lui demander de commencer par les cours préalables, vérifier les acquis par un petit exercice, puis accompagner une tâche à la fois. Toute notion nouvelle nécessaire doit être expliquée avant usage. Les changements de périmètre sont notés pour la revue, pas ajoutés silencieusement au sprint. Fabien doit pouvoir refaire et expliquer ce qu'il a produit.

## 10. Décisions encore ouvertes

- Confirmation de Windows comme première cible de livraison.
- Ajustement du rythme après S0 et S1 ; aucun calendrier ferme avant ces retours.

État actuel : document de cadrage créé ; aucun logiciel installé, aucun code de jeu produit, aucun dépôt distant créé dans cette étape.
