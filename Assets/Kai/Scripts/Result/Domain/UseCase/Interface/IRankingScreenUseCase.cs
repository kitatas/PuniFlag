using Kai.Common.Application;
using Kai.Common.Data.Entity;

namespace Kai.Result.Domain.UseCase.Interface
{
    public interface IRankingScreenUseCase
    {
        LanguageType language { get; }
        RankingScreen rankingScreen { get; }
    }
}