using System;

namespace GrovsenorPracticum
{
    public class Processor : IProcessor
    {
        private readonly IInputParser _inputParser;

        public Processor() : this(new InputParser()) { }

        public Processor(IInputParser inputParser)
        {
            _inputParser = inputParser ?? new InputParser();
        }

        public void Process(string[] inputString)
        {
            string input;
            if (inputString == null)
            {
                Console.WriteLine("Please enter your input");
                input = Console.ReadLine();
            }
            else
            {
                input = inputString[0];
            }

            var result = _inputParser.ParseInput(input);
            Console.WriteLine(result);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
