using System.Text;

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

        // number 2
        string[] arrOfStr = new[] { "Pendanaan", "Terproteksi", "Untuk", "Dampak", "Berarti" };

        CharSorting cs = new CharSorting();
        cs.Sorting(arrOfStr);
    }
}