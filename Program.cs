using Mastermind;

Console.WriteLine("======================" +
    "\nWelcome to Mastermind!" +
    "\n======================" +
    "\n" +
    "\nHow to play:" +
    "\n" +
    "\nYou will first enter the length of the secret combination the program will create. " +
    "\n(the longer the code is the harder it will be to crack!)" +
    "\n" +
    "\nThen, you will guess which colours you think might be in each part of the secret combination." +
    "\n" +
    "\nAfter each guess, you will recieve feedback on how many of your submitted colours are: " +
    "\n- Within the secret combination, and correctly placed." +
    "\n- Within the secret combination, but not in the correct place." +
    "\n" +
    "\nFrom there it is down to you to use different colour combinations along with the hints given to you" +
    "\nin order to figure out the secret combination." +
    "\n" +
    "\nHint: There will never be multiple of one colour within the secret combination." +
    "\n" +
    "\nPRESS ENTER TO BEGIN");
Console.ReadLine();
Console.Clear();

Console.WriteLine("Please enter the length of the secret combination:" +
    "\n(Between 1-10)");
int listLength = InputListLength();
Console.Clear();

List<string> secretCombination = GenerateNewCombination(listLength);

var previousGuesses = new List<Guess>();
List<string> currentGuess = new();
int guessNumber = 0;
bool loop = true;
while (loop)
{
    guessNumber++;
    currentGuess = new();

    if (previousGuesses.Count > 0)
    {
        Console.Clear();
        foreach (Guess guess in previousGuesses)
        {
            guess.DisplayGuessInfo();
        }
        Console.WriteLine("\nPRESS ENTER TO CONTINUE");
        Console.ReadLine();
        Console.Clear();
    }

    List<string> possibleColours = new() { "white", "black", "brown", "red", "blue", "green", "yellow", "pink", "orange", "purple" };

    for (int i = 0; i < listLength; i++)
    {
        Console.WriteLine("\nPossible Colours:");
        foreach (string colour in possibleColours)
        {
            Console.Write($"{colour}, ");
        }
        Console.WriteLine($"\nPosition {i + 1}" +
            $"\nYour Guess: \n");

        string? colourGuess = Console.ReadLine();
        while (string.IsNullOrEmpty(colourGuess) || !possibleColours.Contains(colourGuess))
        {
            Console.WriteLine("Please enter a valid colour.");
            colourGuess = Console.ReadLine();
        }
        possibleColours.Remove(colourGuess);
        currentGuess.Add(colourGuess);
    }

    int wellPlacedColours = GetWellPlacedColours(secretCombination, currentGuess);
    int correctButMisplacedColours = GetCorrectButMisplacedColours(secretCombination, currentGuess);

    Guess newGuess = new(guessNumber, currentGuess, wellPlacedColours, correctButMisplacedColours);
    previousGuesses.Add(newGuess);

    if (wellPlacedColours == secretCombination.Count)
    {
        loop = false;
    }
}
Console.Clear();
Console.WriteLine("\nCONGRATULATIONS!" +
    $"\nYou cracked the secret combination in {previousGuesses.Count} guesses!");

int GetWellPlacedColours(List<string> secretCombination, List<string> currentGuess)
{
    int counter = 0;
    for (int i = 0; i < secretCombination.Count; i++)
    {
        if (currentGuess[i] == secretCombination[i])
        {
            counter++;
        }
    }
    return counter;
}

int GetCorrectButMisplacedColours(List<string> secretCombination, List<string> currentGuess)
{
    int counter = 0;
    List<int> indexesOfCorrectColours = new();
    for (int i = 0; i < secretCombination.Count; i++)
    {
        if (currentGuess[i] == secretCombination[i])
        {
            indexesOfCorrectColours.Add(i);
        }
    }
    for (int i = 0; i < secretCombination.Count; i++)
    {
        if (secretCombination.Contains(currentGuess[i]) && !indexesOfCorrectColours.Contains(i))
        {
            counter++;
        }
    }
    return counter;
}

int InputListLength()
{
    int number;
    while (!int.TryParse(Console.ReadLine(), out number) || number > 10 || number < 1)
    {
        Console.WriteLine("\nPlease enter a valid integer between 1-10.\n");
    }
    return number;
}

List<string> GenerateNewCombination(int listLength)
{
    List<string> secretCombination = new();
    List<int> previousNumbers = new();
    for (int i = 0; i < listLength; i++)
    {
        int randomNumber = new Random().Next(10);
        while (previousNumbers.IndexOf(randomNumber) != -1)
        {
            randomNumber = new Random().Next(10);
        }
        switch (randomNumber)
        {
            case 0:
                secretCombination.Add("white");
                break;

            case 1:
                secretCombination.Add("red");
                break;

            case 2:
                secretCombination.Add("blue");
                break;

            case 3:
                secretCombination.Add("green");
                break;

            case 4:
                secretCombination.Add("yellow");
                break;

            case 5:
                secretCombination.Add("pink");
                break;

            case 6:
                secretCombination.Add("orange");
                break;

            case 7:
                secretCombination.Add("purple");
                break;

            case 8:
                secretCombination.Add("black");
                break;

            case 9:
                secretCombination.Add("brown");
                break;
        }
    }
    return secretCombination;
}