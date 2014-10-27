namespace GrovsenorPracticumTest.PracticumTests
{
    public class when_input_is_null : given_an_processor
    {
        #region Overrides of given_an_processor

        protected override string[] InputValue
        {
            get { return null; }
        }

        protected override string ExpectedResult
        {
            get { return "Please enter your input\r\n\r\nPress any key to continue.\r\n"; }
        }

        #endregion
    }
}
