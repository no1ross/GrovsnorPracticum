namespace GrovsenorPracticumTest.PracticumTests
{
    public class when_input_is_not_null : given_an_processor
    {
        #region Overrides of given_an_processor

        protected override string[] InputValue
        {
            get { return new[] {"morning, 1"}; }
        }

        protected override string ExpectedResult
        {
            get { return "\r\nPress any key to continue.\r\n"; }
        }

        #endregion
    }
}
