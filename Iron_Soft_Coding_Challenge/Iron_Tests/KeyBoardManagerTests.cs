using Iron_Console;

namespace Iron_Tests
{
    /// <summary>
    /// KeyboardManagerTests class to test the KeyboardManager
    /// </summary>
    public class KeyboardManagerTests
    {
        /// <summary>
        /// OutputEmptyForInvalidInput method to test the empty output for invalid input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("", "")]
        [InlineData("AA#", "")]
        [InlineData("!@#$%^#", "")]
        public void OutputEmptyForInvalidInput(string input, string expected)
        {
            //Act
            string actual = KeyBoardManager.OldPhonePad(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// ValidateOldPhonePad method to test the output for valid input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void ValidateOldPhonePad(string input, string expected)
        {
            // Act
            string actual = KeyBoardManager.OldPhonePad(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}