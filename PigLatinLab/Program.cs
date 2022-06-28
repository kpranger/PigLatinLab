//Start to loop the program
bool runProgram = true;
Console.WriteLine("Welcome to the Pig Latin Translator!");
while (runProgram)
{
    //The application prompts the user for a word.
    Console.WriteLine("\n" + "Enter a sentence to be translated: ");
    string userInput = Console.ReadLine().ToLower().Trim();

    //Make the application take a line instead of a single word, and then find the Pig Latin for each word in the line.
    string[] sentence = userInput.Split(" ");
    string result = " ";
    foreach (string word in sentence)
    {
        char firstChar = word[0];

        if (firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u')
        {
            string x = vowelCheck(word);
            result += x + " ";
        }
        else
        {
            string x = moveFirstLetter(word);
            result += x + " ";
        }
    }

    //The application translates the text to Pig Latin and displays it on the console.
    Console.WriteLine(result);

    //The application asks the user if he or she wants to translate another word.
    Console.WriteLine("\n" + "Would you like to translate another sentence? y/n");
    string loopChoice = Console.ReadLine().ToLower().Trim();
    if (loopChoice == "y")
    {
        runProgram = true;
    }
    else
    {
        break;
    }
}

//If a word starts with a vowel, just add “way” onto the ending. 
static string vowelCheck(string word)
{
    char[] wordBank = new char[] { 'a', 'e', 'i', 'o', 'u' };
    string modified = " ";
    foreach (char letter in wordBank)
    {
        if (word.StartsWith(letter) == true)
        {
            word += "way";
        }
    }
    return word;
}

//If a word starts with a consonant, move all of the consonants that appear before the first vowel to the end of the word, then add “ay” to the end of the word. 
static string moveFirstLetter(string word)
{
    string modified = " ";
    bool cons = true;
    int i = 1;
    while (cons && i < word.Length)
    {
        if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
        {
            modified = word.Substring(i) + word.Substring(0, i) + "ay";
            cons = false;
        }
        else
        {
            i++;
        }
    }
    return modified;
}