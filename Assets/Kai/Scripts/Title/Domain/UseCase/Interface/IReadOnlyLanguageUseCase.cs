using Kai.Common.Application;
using Kai.Common.Data.DataStore;
using UniRx;

namespace Kai.Title.Domain.UseCase.Interface
{
    public interface IReadOnlyLanguageUseCase
    {
        IReadOnlyReactiveProperty<LanguageType> language { get; }
        LanguageData GetLanguageData(LanguageType languageType);
    }
}