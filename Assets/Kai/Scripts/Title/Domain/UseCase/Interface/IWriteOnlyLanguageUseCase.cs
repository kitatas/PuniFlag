using Kai.Common.Application;

namespace Kai.Title.Domain.UseCase.Interface
{
    public interface IWriteOnlyLanguageUseCase
    {
        void SetLanguage(LanguageType languageType);
    }
}