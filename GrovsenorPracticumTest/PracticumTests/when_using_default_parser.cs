namespace GrovsenorPracticumTest.PracticumTests
{
    public class when_using_default_parser : given_an_processor
    {
        #region Overrides of given_an_processor

        protected override string[] InputValue
        {
            get { return new[] { "morning, 1" }; }
        }

        protected override string ExpectedResult
        {
            get { return "eggs\r\nPress any key to continue.\r\n"; }
        }

        #region Overrides of given_an_processor

        protected override bool UseMoqProcessor
        {
            get { return false; }
        }

        #endregion

        #endregion
    }
}
