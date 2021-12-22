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

        public uint AskForUIntInput(string prompt)
        {
            do
            {
                string input = AskForStrInput(prompt);
                if (uint.TryParse(input, out uint answer)) return answer;

            } while (true);
        }


        public void PrintString(string message)
        {
            Console.WriteLine(message);
        }
    }
}
