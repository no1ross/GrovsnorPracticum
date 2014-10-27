namespace GrovsenorPracticumTest.InputParserTests
{
    public class when_input_is_bad_time_of_day : given_an_input_parser
    {
        protected override string InputValue
        {
            get { return "moning, 1, 2"; }
        }

        protected override string ExpectedResult
        {
            get { return "You must enter time of day as 'morning' or 'night'"; }
        }
    }
}
