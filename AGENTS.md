# Living Elsewhere — Consignes de collaboration

## Mode d'apprentissage

- Fabien connaît Java, JavaScript et TypeScript. Ne pas réexpliquer les bases générales de la programmation ; se concentrer sur les particularités de C#, .NET et Godot.
- Expliquer le but de chaque nouvelle notion et de chaque commande avant de demander à Fabien de l'utiliser.
- Garder un rythme soutenu et ajuster le niveau de détail selon les questions de Fabien.
- Fabien écrit et modifie lui-même le code afin d'apprendre.
- Ne pas créer ou modifier les fichiers de code à sa place, sauf demande explicite.
- Pour l'aider, privilégier les explications, les questions ciblées et les indices progressifs avant de fournir une solution complète.

## Actions sur le projet

- Les opérations de lecture, de diagnostic et de vérification peuvent être réalisées directement.
- Ne jamais effectuer de `git add`, commit, push, création de branche, publication ou déploiement sans demande explicite de Fabien.
- Ne pas installer de dépendance ou d'outil supplémentaire sans en avoir expliqué le besoin.
- Préserver les modifications existantes et ne pas supprimer de fichier sans demande explicite.

## Principes du jeu

- Le projet s'appelle **Living Elsewhere**. Le nom technique est `LivingElsewhere`.
- Le C# pur détient la vérité de la simulation ; l'interface et le LLM ne décident pas arbitrairement des faits du monde.
- Le LLM peut interpréter ou raconter des faits structurés, mais toute modification de l'état du jeu doit être validée par le moteur.
- Construire progressivement et appliquer YAGNI : ne créer une abstraction ou un service que lorsqu'un besoin concret apparaît.
- Commencer par une application console C# avant d'intégrer Godot.
- La première cible jouable reste : un aventurier, une quête, une résolution et une mémoire structurée.

## Source de vision à long terme

- La page Notion [C#/Godot : Projet Isekai](https://app.notion.com/p/3d68ab997000818b9baecbba1c2fdfb7) et ses sous-pages regroupent la vision, les objectifs et les idées vers lesquels **Living Elsewhere** peut tendre.
- Consulter cette page avant de cadrer un nouveau sprint, de prendre une décision d'architecture importante ou d'introduire une mécanique majeure, ainsi que lorsque Fabien demande de revoir la direction du projet.
- Ne pas relire Notion pour chaque modification mineure ou exercice local.
- Les idées exploratoires de Notion sont une direction de conception, pas des fonctionnalités automatiquement approuvées. Ne rien ajouter au sprint actif sans validation explicite de Fabien.
