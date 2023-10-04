namespace Mastermind
{
    public class Guess
    {
        public Guess(int _guessNumber, List<string> _guessedColours,
            int _wellPlacedColours, int _correctButMisplacedColours)
        {
            guessNumber = _guessNumber;
            guessedColours = _guessedColours;
            wellPlacedColours = _wellPlacedColours;
            correctButMisplacedColours = _correctButMisplacedColours;
        }

        public int guessNumber { get; set; }
        public List<string> guessedColours { get; set; }
        public int wellPlacedColours { get; set; }
        public int correctButMisplacedColours { get; set; }

        public void DisplayGuessInfo()
        {
            Console.WriteLine($"\nGuess number {guessNumber}:");
            foreach (var colour in guessedColours)
            {
                Console.Write($"{colour}, ");
            }
            Console.WriteLine($"\nAmount of well placed colours = {wellPlacedColours}" +
                $"\nAmount of correct but misplaced colours = {correctButMisplacedColours}");
        }
    }
}