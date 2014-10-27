namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_has_too_few_parameters : given_an_input_parser
    {
        #region Overrides of given_an_input_parser_test

        protected override string InputValue
        {
            get { return "morning"; }
        }

        protected override string ExpectedResult
        {
            get { return "You must enter a comma delimited list of dish types with at least one selection"; }
        }

        #endregion
    }
}
