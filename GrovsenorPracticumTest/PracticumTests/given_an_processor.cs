using System;
using System.IO;
using GrovsenorPracticum;
using Moq;
using NUnit.Framework;
using SpecsFor;

namespace GrovsenorPracticumTest.PracticumTests
{
    public abstract class given_an_processor : SpecsFor<Processor>
    {
        protected IProcessor Processor;
        protected string ActualResult;
        private TextWriter currentConsoleOut; 

        #region Overrides of SpecsFor<ParamValidator>

        protected override void Given()
        {
            if (UseMoqProcessor)
            {
                var moqParser = new Mock<IInputParser>();
                Processor = new Processor(moqParser.Object);
            }
            else
            {
                Processor = new Processor();
            }

            currentConsoleOut = Console.Out;
        }

        protected override void When()
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                Processor.Process(InputValue);
                ActualResult = consoleOutput.GetOuput();
            }
        }

        #endregion

        protected abstract string[] InputValue { get; }
        protected abstract string ExpectedResult { get; }

        protected virtual bool UseMoqProcessor
        {
            get { return true; }
        }

        [Test]
        public void VerirfyConsoleOutput()
        {
            Assert.AreEqual(ExpectedResult, ActualResult);

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}
