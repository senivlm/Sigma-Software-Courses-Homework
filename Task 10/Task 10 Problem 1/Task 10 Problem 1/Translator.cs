using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Translator
{
    private Dictionary<string, string> vocabluary;
    private string text;
    private string pathToText;
    private string pathToDictionary;
    private int countVariedle = 3;

    public Translator() : this(@"../../../Text.txt", @"../../../Dictionary.txt")
    {

    }

    public Translator(string pathToText, string pathToDictionary)
    {
        vocabluary = new Dictionary<string, string>();
        text = "";
        this.pathToText = pathToText;
        this.pathToDictionary = pathToDictionary;
    }

    public Translator(Dictionary<string, string> vocabluary, string text, string pathToText, string pathToDictionary)
    {
        this.pathToText = pathToText;
        this.pathToDictionary = pathToDictionary;
        this.vocabluary = vocabluary;
        this.text = text;
    }

    public void AddText(string text)
    {
        this.text += text;
    }

    public void AddDictionary(Dictionary<string, string> dictionary)
    {
        this.vocabluary = dictionary;
    }

    public string ChangeWords()
    {
        string result = "";
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            char temp = ' ';
            string tempWord = "";
            int i = 0;
            if (Char.IsPunctuation(word[word.Length - 1]))
            {
                temp = word[word.Length - 1];
                while (!vocabluary.ContainsKey(word[0..^1]) && i < countVariedle)
                {
                    AddToDictionary(word[0..^1]);
                    i++;
                }
                tempWord = vocabluary[word[0..^1]] + temp;
            }
            else
            {
                while (!vocabluary.ContainsKey(word) && i < countVariedle)
                {
                    AddToDictionary(word);
                    i++;
                }
                tempWord = vocabluary[word];
            }
            result += tempWord + " ";
        }

        return result;
    }

    private void AddToDictionary(string word)
    {
        Console.WriteLine($"Введiть замiну для слова {word}");
        string value = Console.ReadLine();
        vocabluary.Add(word, value);
        Reader.WriteToDictionary(word, value, @"../../../Dictionary.txt");
    }
}