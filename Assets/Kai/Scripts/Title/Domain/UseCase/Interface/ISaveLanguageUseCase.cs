using Kai.Common.Application;

namespace Kai.Title.Domain.UseCase.Interface
{
    public interface ISaveLanguageUseCase
    {
        LanguageType language { get; }
        void SaveLanguage(LanguageType languageType);
    }
}