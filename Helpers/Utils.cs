namespace OnneaRE.Helpers;
internal static class Utils
{
    internal static string GetLanguage(string text)
    {
        int pFrom = text.IndexOf(".") + ".".Length;
        int pTo = text.LastIndexOf(".");
        if (pFrom > pTo) return "English";
        String result = text.Substring(pFrom, pTo - pFrom);
        switch (result.ToLower())
        {
            case "fi":
                return "Finnish";
            case "sv":
                return "Swedish";
            case "de":
                return "German";
            case "es":
                return "Spanish";
            case "fr":
                return "French";
            case "ru":
                return "Russian";
            case "it":
                return "Italian";
            case "ja":
                return "Japanese";
            case "ar":
                return "Arabian";
            case "th":
                return "Thai";
            case "be":
                return "Belarusian";
            case "bg":
                return "Bulgarian";
            case "da":
                return "Danish";
            case "et":
                return "Estonian";
            case "hi":
                return "Hindi";
            case "id":
                return "Indonesian";
            case "lt":
                return "Lithuanian";
            case "is":
                return "Icelandic";
            case "lv":
                return "Latvian";
            case "nb":
                return "Norwegian (bokmål)";
            case "pl":
                return "Polish";
            case "pt":
                return "Portuguese";
            case "uk":
                return "Ukranian";
            case "ur":
                return "Urdu";
            case "zh":
                return "Chinese (mandarian)";
            case "cs":
                return "Czech";
            case "el":
                return "Greek";
            case "fa":
                return "Farsi";
            case "he":
                return "Hebrew";
            case "kn":
                return "Kannada";
            case "hu":
                return "Hungarian";
            case "ms":
                return "Malay";
            case "sw":
                return "Swahili";
            case "ro":
                return "Romanian";
            case "tr":
                return "Turkish";
            case "vi":
                return "Vietnamese";
            case "az":
                return "Azerbaijani";
            case "bn":
                return "Bengali";
            case "ko":
                return "Korean";
            default:
                return "English";
        }
    }
}
