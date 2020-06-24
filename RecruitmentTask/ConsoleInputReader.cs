using System;
using System.Collections.Generic;

namespace RecruitmentTask
{
    public class ConsoleInputReader : IInputReader
    {
        private readonly IInputValidator inputValidator;

        public ConsoleInputReader(IInputValidator inputValidator)
        {
            this.inputValidator = inputValidator ?? throw new ArgumentNullException(nameof(inputValidator));
        }

        public IEnumerable<string> Read()
        {
            var inputLines = new List<string>();
            Console.WriteLine("Type one data row in proper format and and hit enter.");
            Console.WriteLine("Type exit to stop reading.");
            string line = Console.ReadLine();

            while (line != "exit")
            {
                if (inputValidator.IsCommentLine(line))
                {
                    Console.WriteLine("Line ignored.");
                    line = Console.ReadLine();
                    continue;
                }

                inputLines.Add(line);
                Console.WriteLine("Line added.");
                line = Console.ReadLine();
            }

            return inputLines;
        }
    }
}