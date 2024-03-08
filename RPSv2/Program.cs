namespace RPSv2
{
    internal class Program
    {
        public class gameObjects
        {
            // Initiieren der spielObjekte / gameObjects
            public static string[] symbolVariants = { "Rock", "Paper", "Scissors" };

            public static string[] rockVariants = { "r", "rock", "stein" };
            public static string[] paperVariants = { "p", "paper", "papier" };
            public static string[] scissorsVariants = { "s", "scissors", "schere" };

            public static string[] exitVariants = { "e", "exit", "q", "quit" };
            public static string[] agreeingVariants = { "y", "yes"};
            public static string[] denyingVariants = { "n", "no"};
            public static string[] replayingVariants = { "r", "replay", "reset", "new", "new game" };

            public static string welcomingMessage = "Welcome to Rock, Paper, Scissors!\n";

            public static string selectionMessage = ($"Enter one of the following to your choosing.\n\n" +
                                                     $"{string.Join(", ", gameObjects.rockVariants)} = {gameObjects.symbolVariants[0]}\n" +
                                                     $"{string.Join(", ", gameObjects.paperVariants)} = {gameObjects.symbolVariants[1]}\n" +
                                                     $"{string.Join(", ", gameObjects.scissorsVariants)} = {gameObjects.symbolVariants[2]}\n");

            public static string quittingMessage = $"Game automatically continues. Enter {string.Join(", ", gameObjects.exitVariants)} to exit / quit the game.\n";

            public static string informationMessage = ("First one to reach three points wins the game.\n" +
                                                       "Upper - or Lowercase does not matter.\n" +
                                                      $"{gameObjects.quittingMessage}");
        }

        public static void determineRoundWinner(ref int[] gameScore, int userChoice, int randomChoice)
        {
            Console.WriteLine($"You have chosen {gameObjects.symbolVariants[userChoice]}. CPU chose {gameObjects.symbolVariants[randomChoice]}.");
            if (userChoice == randomChoice)
            {
                Console.WriteLine($"{gameObjects.symbolVariants[userChoice]} can't beat {gameObjects.symbolVariants[randomChoice]}. It's a tie!\n");
            }

            else if ((gameObjects.symbolVariants[userChoice] == "Rock" && gameObjects.symbolVariants[randomChoice] == "Scissors") ||
                     (gameObjects.symbolVariants[userChoice] == "Paper" && gameObjects.symbolVariants[randomChoice] == "Rock") ||
                     (gameObjects.symbolVariants[userChoice] == "Scissors" && gameObjects.symbolVariants[randomChoice] == "Paper"))
            {
                Console.WriteLine($"{gameObjects.symbolVariants[userChoice]} beats {gameObjects.symbolVariants[randomChoice]}. You have won!\n");
                ++gameScore[0];
            }

            else if ((gameObjects.symbolVariants[userChoice] == "Rock" && gameObjects.symbolVariants[randomChoice] == "Paper") ||
                     (gameObjects.symbolVariants[userChoice] == "Paper" && gameObjects.symbolVariants[randomChoice] == "Scissors") ||
                     (gameObjects.symbolVariants[userChoice] == "Scissors" && gameObjects.symbolVariants[randomChoice] == "Rock"))
            {
                Console.WriteLine($"{gameObjects.symbolVariants[userChoice]} is beaten by {gameObjects.symbolVariants[randomChoice]}. CPU has won!\n");
                ++gameScore[1];
            }

            Console.WriteLine($"Player Score: {gameScore[0]}, CPU Score: {gameScore[1]}\n");   
        }

        public static void determineGameWinner(ref int[] gameScore, ref int determinedWinner)
        {
            // Überprüfung ob das Spiel gewonnen wurde, und ob das Spiel zuvor gewonnen worden ist
            if (gameScore[0] == 3 && determinedWinner == 0)
            {
                Console.WriteLine("Player has won the game.\n");
                ++determinedWinner;
            }
            else if (gameScore[1] == 3)
            {
                Console.WriteLine("CPU has won the game.\n");
                ++determinedWinner;
            }

            if (gameScore.Contains(3) && determinedWinner == 1)
            {
                Console.WriteLine("Would you like to continue the game?\n\n" +
                                  $"Enter {string.Join(", ", gameObjects.agreeingVariants)} to continue the game,\n" +
                                  $"{string.Join(", ", gameObjects.denyingVariants)} to exit the game\n" +
                                  $"{string.Join(", ", gameObjects.replayingVariants)} to start a new game.\n");

                string userInput = Console.ReadLine().ToLower();

                if (gameObjects.agreeingVariants.Contains(userInput))
                {
                    Console.Clear();
                    gameRound(ref gameScore, ref determinedWinner);
                }

                else if (gameObjects.denyingVariants.Contains(userInput))
                {
                    Console.Clear();
                    Console.WriteLine("Good Bye!");
                    Environment.Exit(0);
                }

                else if (gameObjects.replayingVariants.Contains(userInput))
                {
                    Console.Clear();
                    gameRound(ref gameScore, ref determinedWinner);
                }
            }
        }
        public static void gameRound(ref int[] gameScore, ref int determinedWinner)
        {
            Console.WriteLine(gameObjects.informationMessage);
            Console.WriteLine(gameObjects.selectionMessage);

            // Initiieren der Auswahlsvariablen
            int userChoice, randomChoice;

            // Zuordnung einer zufaellige Zahl zur Auswahl eines Symbols / Zeichens / einer Option
            Random rndm = new Random();
            randomChoice = rndm.Next(0, 3);

            string userInput = Console.ReadLine().ToLower();
            Console.Clear();

            if (gameObjects.rockVariants.Contains(userInput))
            {
                userChoice = Array.IndexOf(gameObjects.symbolVariants, "Rock");
                determineRoundWinner(ref gameScore, userChoice, randomChoice);
            }

            else if (gameObjects.paperVariants.Contains(userInput))
            {
                userChoice = Array.IndexOf(gameObjects.symbolVariants, "Paper");
                determineRoundWinner(ref gameScore, userChoice, randomChoice);
            }

            else if (gameObjects.scissorsVariants.Contains(userInput))
            {
                userChoice = Array.IndexOf(gameObjects.symbolVariants, "Scissors");
                determineRoundWinner(ref gameScore, userChoice, randomChoice);
            } 

            else if (gameObjects.exitVariants.Contains(userInput))
            {
                Console.Clear();
                Console.WriteLine("Good Bye!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            else
                Console.WriteLine("Symbol not found.\n");

            determineGameWinner(ref gameScore, ref determinedWinner);
            gameRound(ref gameScore, ref determinedWinner);
        }

        public static void Game()
        {
            int[] gameScore = { 0, 0 };
            int determinedWinner = 0;
            gameRound(ref gameScore, ref determinedWinner);
        }
        static void Main()
        {
            // Begrüßung
            Console.WriteLine(gameObjects.welcomingMessage);

            // Spielinitiierung
            Game();
        }
    }
}


/* 
 * Meiner Meinung nach besteh immenser Verbesserungsbedarf, ich bin mir sicher, dass man dieses Programm noch weiter kürzen könnte.
 * Ebenfalls bin ich mit dem Spiellayout nicht ganz zufrieden. 
 */