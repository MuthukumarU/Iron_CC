using System.Text;

namespace Iron_Console
{
    /// <summary>
    /// KeyboardManager class to handle the old phone pad input
    /// </summary>
    public class KeyBoardManager
    {
        /// <summary>
        /// hardcoded keyboard inputs
        /// </summary>
        static readonly string[] KeyPad = {
                            " ",    // 0
                            "",     // 1 (usually not used)
                            "ABC",  // 2
                            "DEF",  // 3
                            "GHI",  // 4
                            "JKL",  // 5
                            "MNO",  // 6
                            "PQRS", // 7
                            "TUV",  // 8
                            "WXYZ"  // 9
                    };

        /// <summary>
        /// OldPhonePad method to process the input from the old phone pad
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            StringBuilder output = new();
            char lastKey = '\0';  // To track the last pressed key
            int pressCount = 0;   // To count how many times the key is pressed

            foreach (char key in input)
            {
                //end of line
                if (key == '#')
                {
                    break;
                }
                else if (key == '*')
                {
                    // Reset lastKey and pressCount
                    lastKey = '\0';
                    pressCount = 0;
                }
                else if (key == ' ')
                {
                    // A new key is pressed, process the previous key
                    int index = (pressCount - 1) % KeyPad[lastKey - '0'].Length;
                    output.Append(KeyPad[lastKey - '0'][index]);

                    // Pause: reset the lastKey and pressCount
                    lastKey = '\0';
                    pressCount = 0;
                }
                else if (char.IsDigit(key) && key != '0' && key != '1')
                {
                    // Handle regular key presses
                    if (key == lastKey)
                    {
                        // If the same key is pressed again, increment pressCount
                        pressCount++;
                    }
                    else
                    {
                        // A new key is pressed, process the previous key
                        if (lastKey != '\0' && char.IsDigit(lastKey))
                        {
                            int index = (pressCount - 1) % KeyPad[lastKey - '0'].Length;
                            output.Append(KeyPad[lastKey - '0'][index]);
                        }
                        // Update lastKey and reset pressCount
                        lastKey = key;
                        pressCount = 1;
                    }
                }
            }

            // Process the last key press (if any)
            if (lastKey != '\0' && char.IsDigit(lastKey))
            {
                int index = (pressCount - 1) % KeyPad[lastKey - '0'].Length;
                output.Append(KeyPad[lastKey - '0'][index]);
            }

            return output.ToString();
        }
    }
}