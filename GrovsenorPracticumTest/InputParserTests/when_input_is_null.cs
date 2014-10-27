namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_is_null : given_an_input_parser
    {
        #region Overrides of given_an_input_parser

        protected override string InputValue
        {
            get { return null; }
        }

        protected override string ExpectedResult
        {
            get { return "error"; }
        }

        #endregion
    }
}
