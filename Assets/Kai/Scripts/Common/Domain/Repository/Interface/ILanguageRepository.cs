using Kai.Common.Application;
using Kai.Common.Data.Entity;
using UnityEngine;

namespace Kai.Common.Domain.Repository.Interface
{
    public interface ILanguageRepository
    {
        LanguageScreenData Find(LanguageType languageType);
        Sprite GetLogo(LanguageType languageType);
    }
}