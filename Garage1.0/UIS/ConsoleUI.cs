using System;

namespace Garage1._0
{
    public class ConsoleUI : IUI
    {
        public string AskForStrInput(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                PrintString($"{prompt}: ");
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    PrintString($"You must enter a {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public int AskForIntInputWithLimit(string prompt,int min,int max)
        {
            bool success = false;
            int answer;

            do
            {
                PrintString($"{prompt}: ");
                answer = int.Parse(Console.ReadLine());

                if (answer < min || answer > max )
                {
                    PrintString($"You must enter a {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }
        
        public int AskForIntInput(string prompt)
        {
            do
            {
                string input = AskForStrInput(prompt);
                if (int.TryParse(input, out int answer)) return answer;

            } while (true);
        }
        public void Rkey()
        {
            Console.ReadKey();
        }

        public void PrintString(string message)
        {
            Console.WriteLine(message);
        }
    }
}
