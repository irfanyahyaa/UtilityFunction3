using System.Text;

namespace SWIDDotnet;

public class CharSorting
{
    public void Sorting(string[] arrOfStr)
    {
        StringBuilder upper = new StringBuilder();
        StringBuilder lower = new StringBuilder();

        // split upper and lower
        foreach (string s in arrOfStr)
        {
            foreach (char c in s)
            {
                if (Char.IsUpper(c))
                {
                    upper.Append(c);
                }
                else
                {
                    lower.Append(c);
                }
            }
        }

        char[] upperCharArray = upper.ToString().ToCharArray();
        char[] lowerCharArray = lower.ToString().ToCharArray();
        Array.Sort(upperCharArray);
        Array.Sort(lowerCharArray);

        // add key, value on dictionary
        Dictionary<char, int> charsUpper = new Dictionary<char, int>();
        Dictionary<char, int> charsLower = new Dictionary<char, int>();

        foreach (char c in upperCharArray)
        {
            if (!charsUpper.TryAdd(c, 1))
            {
                charsUpper[c]++;
            }
        }

        foreach (char c in lowerCharArray)
        {
            if (!charsLower.TryAdd(c, 1))
            {
                charsLower[c]++;
            }
        }

        // sorting depend on value
        List<KeyValuePair<char, int>> charsUpperList = new List<KeyValuePair<char, int>>(charsUpper);
        List<KeyValuePair<char, int>> charsLowerList = new List<KeyValuePair<char, int>>(charsLower);
        List<KeyValuePair<char, int>> mergedList = new List<KeyValuePair<char, int>>();

        for (var i = 0; i < charsUpperList.Count; i++)
        {
            for (var j = 0; j < charsUpperList.Count - i - 1; j++)
            {
                if (charsUpperList[j].Value < charsUpperList[j + 1].Value)
                {
                    (charsUpperList[j], charsUpperList[j + 1]) = (charsUpperList[j + 1], charsUpperList[j]);
                }
            }
        }

        mergedList.AddRange(charsUpperList);

        for (var i = 0; i < charsLowerList.Count; i++)
        {
            for (var j = 0; j < charsLowerList.Count - i - 1; j++)
            {
                if (charsLowerList[j].Value < charsLowerList[j + 1].Value)
                {
                    (charsLowerList[j], charsLowerList[j + 1]) = (charsLowerList[j + 1], charsLowerList[j]);
                }
            }
        }

        mergedList.AddRange(charsLowerList);

        for (var i = 0; i < mergedList.Count; i++)
        {
            for (var j = 0; j < mergedList.Count - i - 1; j++)
            {
                if (mergedList[j].Value < mergedList[j + 1].Value)
                {
                    (mergedList[j], mergedList[j + 1]) = (mergedList[j + 1], mergedList[j]);
                }
            }
        }
        
        Print(mergedList);
    }

    private Dictionary<char, int> ConvertToDictionary(char[] arrOfChar)
    {
        return null;
    }

    private List<KeyValuePair<char, int>> SortUtil(Dictionary<char, int> dictionary)
    {
        return null;
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