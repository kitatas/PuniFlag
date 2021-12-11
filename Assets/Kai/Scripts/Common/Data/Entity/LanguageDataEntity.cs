using System;
using Kai.Common.Application;

namespace Kai.Common.Data.Entity
{
    public sealed class LanguageDataEntity
    {
        public LanguageType type;
        public LanguageData data;
    }

    [Serializable]
    public sealed class LanguageData
    {
        public TitleScreen titleScreen;
        public ConfigScreen configScreen;
        public ExplainScreen explainScreen;
        public InformationScreen informationScreen;
        public RankingScreen rankingScreen;
    }

    [Serializable]
    public sealed class TitleScreen
    {
        public TextData title;
        public TextData subTitle;
        public TextData puni;
        public TextData flag;
    }

    [Serializable]
    public sealed class ConfigScreen
    {
        public TextData language;
        public TextData volume;
    }

    [Serializable]
    public sealed class ExplainScreen
    {
        public ExplainData gravity;
        public ExplainData rotate;
        public ExplainData move;
        public ExplainData reset;
        public ExplainData step;
        public ExplainData flag;
    }

    [Serializable]
    public sealed class ExplainData
    {
        public TextData title;
        public TextData detail;
    }

    [Serializable]
    public sealed class InformationScreen
    {
        public TextData credit;
        public TextData license;
        public TextData privacyPolicy;
    }

    [Serializable]
    public sealed class RankingScreen
    {
        public TextData input;
        public TextData notice;
    }

    [Serializable]
    public sealed class TextData
    {
        public string text;
    }
}