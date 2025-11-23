namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter your name: ");
            string name = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Invalid name. Exiting.");
                return;
            }

            string fileName = name + ".txt";
            int score = 0;

            if (System.IO.File.Exists(fileName))
            {
                string text = System.IO.File.ReadAllText(fileName);
                int.TryParse(text, out score);
            }

            System.Console.WriteLine("\nStarting score: " + score);
            System.Console.WriteLine("Press keys to gain points. Press ENTER to end.\n");

            while (true)
            {
                var key = System.Console.ReadKey(true);

                if (key.Key == System.ConsoleKey.Enter)
                    break;

                score++;
                System.Console.WriteLine("Score: " + score);
            }

            System.IO.File.WriteAllText(fileName, score.ToString());

            System.Console.WriteLine("\nGame over! Final score saved to " + fileName);
            System.Console.ReadKey();
        }
    }
}
