using Kai.Common.Application;
using Kai.Game.Application;

namespace Kai.Common.Data.Entity
{
    public sealed class SaveData
    {
        public float bgmVolume;
        public float seVolume;
        public LanguageType language;
        public ColorType iconColor;
        public bool[] rankData;
        public bool[] clearData;
    }
}