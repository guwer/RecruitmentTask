using System;
using System.Collections.Generic;
using System.IO;

namespace RecruitmentTask
{
    internal class Program
    {
        private const string dataFile = "Example.txt";
        private const string dataFolder = "Data";

        private static void Main(string[] args)
        {
            Console.WriteLine("Hit enter to read from console.");
            Console.WriteLine("Type 1 and hit enter to read example data from file.");
            var inputType = Console.ReadLine();

            IInputReader inputReader;
            var validator = new InputValidator();

            if (inputType == "1")
            {
                // could be also passed via args
                var filePath = Path.Combine(AppContext.BaseDirectory, dataFolder, dataFile);
                inputReader = new FileInputReader(validator, filePath);
            }
            else
            {
                inputReader = new ConsoleInputReader(validator);
            }

            var lines = inputReader.Read();

            // default parser configuration
            var parserConfiguation = new InputParserConfiguration();
            var parser = new InputParser(parserConfiguation);
            var inputLines = new List<InputLine>();

            foreach (var line in lines)
            {
                var inputLine = parser.ParseLine(line);
                inputLines.Add(inputLine);
            }

            // Transform
            var converter = new Converter(new WarehouseComparer(), new StockItemComparer());
            var result = converter.Convert(inputLines);

            // Write to output
            foreach (var item in result)
            {
                Console.WriteLine(new WarehouseDisplayDecorator(item, s => new StockItemDisplayDecorator(s)).ToString());
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}