namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_is_moring_2_1_3 : given_an_input_parser
    {
        private const string input = "morning, 2, 1, 3";
        private const string output = "eggs, toast, coffee";

        #region Overrides of ParamValidatorTest

        protected override string ExpectedResult
        {
            get { return output; }
        }

        protected override string InputValue
        {
            get { return input; }
        }

        #endregion
    }
}
