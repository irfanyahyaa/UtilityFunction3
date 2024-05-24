using System.Text;

namespace SWIDDotnet;

public class CharSorting
{
    public void Sorting(string[] arrOfStr)
    {
        StringBuilder uppercase = new StringBuilder();
        StringBuilder lowercase = new StringBuilder();

        // split into uppercase and lowercase
        foreach (string s in arrOfStr)
        {
            foreach (char c in s)
            {
                if (Char.IsUpper(c))
                {
                    uppercase.Append(c);
                }
                else
                {
                    lowercase.Append(c);
                }
            }
        }

        // convert into an array of char data type
        char[] upperCharArray = uppercase.ToString().ToCharArray();
        char[] lowerCharArray = lowercase.ToString().ToCharArray();
        
        // sorting depends on the alphabet
        Array.Sort(upperCharArray);
        Array.Sort(lowerCharArray);

        // convert into dictionary data type, and make the key unique with the value of the sum of keys
        Dictionary<char,int> charsUpper = ConvertToDictionary(upperCharArray);
        Dictionary<char,int> charsLower = ConvertToDictionary(lowerCharArray);

        // sorting depends on the value
        List<KeyValuePair<char, int>> charsUpperList = new List<KeyValuePair<char, int>>(charsUpper);
        List<KeyValuePair<char, int>> charsLowerList = new List<KeyValuePair<char, int>>(charsLower);
        List<KeyValuePair<char, int>> mergedList = new List<KeyValuePair<char, int>>();

        SortUtil(charsUpperList);
        mergedList.AddRange(charsUpperList);

        SortUtil(charsLowerList);
        mergedList.AddRange(charsLowerList);

        SortUtil(mergedList);
        
        // print only the key on the sorted list 
        Print(mergedList);
    }

    private Dictionary<char, int> ConvertToDictionary(char[] arrOfChar)
    {
        Dictionary<char, int> result = new Dictionary<char, int>();

        foreach (char c in arrOfChar)
        {
            if (!result.TryAdd(c, 1))
            {
                result[c]++;
            }
        }
        
        return result;
    }

    private void SortUtil(List<KeyValuePair<char, int>> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            for (var j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j].Value < list[j + 1].Value)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
    }

    private void Print(List<KeyValuePair<char, int>> list)
    {
        int listCount = list.Count;
        int currentCount = 1;

        foreach (KeyValuePair<char, int> pair in list)
        {
            if (currentCount == listCount)
            {
                Console.WriteLine($"{pair.Key}");
            }
            else
            {
                Console.Write($"{pair.Key}, ");
            }

            currentCount++;
        }
    }
}