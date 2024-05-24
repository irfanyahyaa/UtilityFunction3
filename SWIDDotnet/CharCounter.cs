namespace SWIDDotnet;

public class CharCounter
{
    public void Counter(string str)
    {
        string[] loweredStrs = str.ToLower().Split(" ");
        Dictionary<char, int> chars = new Dictionary<char, int>();

        // convert into dictionary data type, and make the key unique with the value of the sum of keys
        foreach (string s in loweredStrs)
        {
            foreach (char c in s)
            {
                if (!chars.TryAdd(c, 1))
                {
                    chars[c]++;
                }
            }
        }

        // print the key and the value according to the requirements 
        Print(chars);
    }

    private void Print(Dictionary<char, int> dict)
    {
        int dictCount = dict.Count;
        int currentCount = 1;

        foreach (KeyValuePair<char, int> pair in dict)
        {
            if (currentCount == dictCount)
            {
                Console.WriteLine("{0}={1}", pair.Key, pair.Value);
            }
            else
            {
                Console.Write("{0}={1}, ", pair.Key, pair.Value);
            }

            currentCount++;
        }
    }
}