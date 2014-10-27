namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_is_night_1_1_2_3_5 : given_an_input_parser
    {
        private const string input = "night, 1, 1, 2, 3, 5";
        private const string output = "steak, error";

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
