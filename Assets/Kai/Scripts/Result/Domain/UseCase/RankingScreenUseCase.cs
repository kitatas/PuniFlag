using Kai.Common.Application;
using Kai.Common.Data.Entity;
using Kai.Common.Domain.Repository.Interface;
using Kai.Result.Domain.UseCase.Interface;

namespace Kai.Result.Domain.UseCase
{
    public sealed class RankingScreenUseCase : IRankingScreenUseCase
    {
        private readonly LanguageScreenData _languageScreenData;

        public RankingScreenUseCase(ISaveDataRepository saveDataRepository, ILanguageRepository languageRepository)
        {
            language = saveDataRepository.Load().language;
            _languageScreenData = languageRepository.Find(language);
        }

        public LanguageType language { get; }

        public RankingScreen rankingScreen => _languageScreenData.rankingScreen;
    }
}