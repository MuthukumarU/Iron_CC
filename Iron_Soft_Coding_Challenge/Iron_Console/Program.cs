namespace Iron_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input for OldPhonePad:");
            string input = Console.ReadLine();
            string output = KeyBoardManager.OldPhonePad(input);
            Console.WriteLine($"Output: {output}");
        }
    }
}
