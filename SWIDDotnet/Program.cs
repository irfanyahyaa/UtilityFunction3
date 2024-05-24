namespace SWIDDotnet;

class Program
{
    static void Main(string[] args)
    {
        // number 1
        string str1 = "We Always Mekar";
        string str2 = "coding is fun";

        CharCounter cc = new CharCounter();
        cc.Counter(str1);
        cc.Counter(str2);
    }
}
