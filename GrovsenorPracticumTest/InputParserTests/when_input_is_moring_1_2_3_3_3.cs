namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_is_moring_1_2_3_3_3 : given_an_input_parser
    {
        private const string input = "morning, 1, 2, 3, 3, 3";
        private const string output = "eggs, toast, coffee(x3)";

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
