using System.Text;

namespace AlchemyAPI
{
    internal static class StringBuilderExtensions
    {
        public static void Append2(this StringBuilder builder, string a, string b)
        {
            builder.Append(a);
            builder.Append(b);
        }
    }
}
