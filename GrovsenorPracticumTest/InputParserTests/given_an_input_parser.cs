using GrovsenorPracticum;
using NUnit.Framework;
using SpecsFor;

namespace GrovsenorPracticumTest.InputParserTests
{
    public abstract class given_an_input_parser : SpecsFor<InputParser>
    {
        protected IInputParser Validator;
        protected string ActualResult;

        #region Overrides of SpecsFor<ParamValidator>

        protected override void Given()
        {
            Validator = new InputParser();
        }

        protected override void When()
        {
            ActualResult = Validator.ParseInput(InputValue);
        }

        #endregion

        protected abstract string InputValue { get; }
        protected abstract string ExpectedResult { get; }

        [Test]
        public void then_we_get_the_correct_output()
        {
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        
    }
}
