using Kai.Common.Application;
using Kai.Common.Data.Entity;
using UniRx;
using UnityEngine;

namespace Kai.Title.Domain.UseCase.Interface
{
    public interface IReadOnlyLanguageUseCase
    {
        IReadOnlyReactiveProperty<LanguageType> language { get; }
        LanguageScreenData GetLanguageData(LanguageType languageType);
        Sprite GetTitleLogo(LanguageType languageType);
    }
}