using LivingElsewhere.Domain;

string message = "Bienvenue dans la Guilde !";
Console.WriteLine(message);

message = "La première aventure commence";
Console.WriteLine(message);

Adventurer firstAdventurer = new Adventurer("Bill le borgne", 1);

Console.WriteLine($"{firstAdventurer.Name} est niveau {firstAdventurer.Level}.");

Adventurer  secondAdventurer = new Adventurer("Zia aux douces fesses", 32);

firstAdventurer.Level++;

Console.WriteLine($"{firstAdventurer.Name} est level {firstAdventurer.Level}.");

Console.WriteLine($"{secondAdventurer.Name} est level {secondAdventurer.Level}.");

Quest firstQuest = new Quest("Les gobelins du vieux pont", 3);

Console.WriteLine($"{firstQuest.Title} - difficulté {firstQuest.Difficulty}.");