using Kai.Common.Application;
using Kai.Common.Data.Entity;
using Kai.Common.Domain.Repository.Interface;
using Kai.Title.Domain.UseCase.Interface;
using UniRx;

namespace Kai.Title.Domain.UseCase
{
    public sealed class LanguageUseCase : IReadOnlyLanguageUseCase, IWriteOnlyLanguageUseCase
    {
        private readonly ReactiveProperty<LanguageType> _language;
        private readonly ILanguageRepository _languageRepository;

        public LanguageUseCase(ISaveDataRepository saveDataRepository, ILanguageRepository languageRepository)
        {
            _language = new ReactiveProperty<LanguageType>(saveDataRepository.Load().language);
            _languageRepository = languageRepository;
        }

        public IReadOnlyReactiveProperty<LanguageType> language => _language;

        public LanguageData GetLanguageData(LanguageType languageType) => _languageRepository.Find(languageType);

        public void SetLanguage(LanguageType languageType) => _language.Value = languageType;
    }
}