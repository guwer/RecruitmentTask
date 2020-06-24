using System;
using System.Collections.Generic;
using System.IO;

namespace RecruitmentTask
{
    public class FileInputReader : IInputReader
    {
        private readonly IInputValidator inputValidator;
        private readonly string filePath;

        public FileInputReader(IInputValidator inputValidator, string filePath)
        {
            this.inputValidator = inputValidator ?? throw new ArgumentNullException(nameof(inputValidator));
            this.filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public IEnumerable<string> Read()
        {
            var inputLines = new List<string>();
            string line;
            
            using (var streamReader = new StreamReader(filePath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (inputValidator.IsCommentLine(line))
                    {
                        continue;
                    }

                    inputLines.Add(line);
                }
            }

            return inputLines;
        }
    }
}
