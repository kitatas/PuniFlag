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
        public string titleName;
        public InfoTitle infoTitle;
        public SubTitle subTitle;
        public Explain explain;
    }

    [Serializable]
    public sealed class InfoTitle
    {
        public string credit;
        public string license;
        public string externalSite;
    }

    [Serializable]
    public sealed class SubTitle
    {
        public string language;
        public string volume;
        public string developer;
        public string sound;
        public string font;
        public string privacyPolicy;
    }

    [Serializable]
    public sealed class Explain
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
        public string title;
        public string detail;
    }
}