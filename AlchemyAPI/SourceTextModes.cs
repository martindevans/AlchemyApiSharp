namespace AlchemyAPI
{
    public enum SourceTextModes
    {
        None,
        CleanedOrRaw,
        Cleaned,
        Raw,
        Cquery,
        Xpath
    }

    internal static class SourceTextModesExtensions
    {
        public static string GetUrlParameter(this SourceTextModes mode)
        {
            if (mode != SourceTextModes.None)
            {
                if (mode == SourceTextModes.CleanedOrRaw)
                    return "&sourceText=cleaned_or_raw";
                else if (mode == SourceTextModes.Cleaned)
                    return "&sourceText=cleaned";
                else if (mode == SourceTextModes.Raw)
                    return "&sourceText=raw";
                else if (mode == SourceTextModes.Cquery)
                    return "&sourceText=cquery";
                else if (mode == SourceTextModes.Cquery)
                    return "&sourceText=xpath";
            }

            return "";
        }
    }
}
