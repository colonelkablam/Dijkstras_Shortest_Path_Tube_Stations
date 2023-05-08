using System.Text;

namespace Testing
{
    // using Hades32's algorithm
    // https://stackoverflow.com/users/52553/hades32 //
    public static class PunctStrip
    {
        public static string fileName(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
