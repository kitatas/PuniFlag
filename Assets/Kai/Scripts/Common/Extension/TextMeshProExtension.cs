using Kai.Common.Data.Entity;
using TMPro;

namespace Kai.Common.Extension
{
    public static class TextMeshProExtension
    {
        public static void SetTextData(this TextMeshProUGUI tmpText, TextData textData)
        {
            tmpText.text = $"{textData.text}";
            tmpText.fontSize = textData.fontSize;
        }
    }
}