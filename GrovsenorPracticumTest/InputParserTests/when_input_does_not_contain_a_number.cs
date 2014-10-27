namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_does_not_contain_a_number : given_an_input_parser
    {
        #region Overrides of given_an_input_parser_test

        protected override string InputValue
        {
            get { return "morning, 1, b, 3"; }
        }

        protected override string ExpectedResult
        {
            get { return "eggs, coffee, error"; }
        }

        #endregion
    }
}
