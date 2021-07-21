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
        public MenuScreen menuScreen;
        public ConfigScreen configScreen;
        public ExplainScreen explainScreen;
        public InformationScreen informationScreen;
        public PolicyScreen policyScreen;
        public RankingScreen rankingScreen;
    }

    [Serializable]
    public sealed class TitleScreen
    {
        public TextData title;
        public TextData subTitle;
        public TextData tap;
        public TextData puni;
        public TextData flag;
    }

    [Serializable]
    public sealed class MenuScreen
    {
        public TextData freePlay;
        public TextData scoreAttack;
        public TextData config;
        public TextData explain;
        public TextData information;
    }

    [Serializable]
    public sealed class ConfigScreen
    {
        public TextData title;
        public TextData language;
        public TextData volume;
    }

    [Serializable]
    public sealed class ExplainScreen
    {
        public TextData title;
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
        public TextData title;
        public TextData credit;
        public TextData developer;
        public TextData sound;
        public TextData font;
        public TextData license;
        public TextData externalSite;
        public TextData privacyPolicy;
        public TextData openPrivacyPolicy;
    }

    [Serializable]
    public sealed class PolicyScreen
    {
        public TextData title;
        public TextData body;
        public TextData yes;
        public TextData no;
    }

    [Serializable]
    public sealed class RankingScreen
    {
        public TextData ranking;
        public TextData score;
        public TextData highScore;
        public TextData tweet;
        public TextData input;
        public TextData notice;
        public TextData send;
        public TextData back;
    }

    [Serializable]
    public sealed class TextData
    {
        public string text;
        public float fontSize;
    }
}