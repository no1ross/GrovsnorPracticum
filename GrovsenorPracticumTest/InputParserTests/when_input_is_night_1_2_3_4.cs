namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_is_night_1_2_3_4 : given_an_input_parser
    {
        private const string input = "night, 1, 2, 3, 4";
        private const string output = "steak, potato, wine, cake";

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
