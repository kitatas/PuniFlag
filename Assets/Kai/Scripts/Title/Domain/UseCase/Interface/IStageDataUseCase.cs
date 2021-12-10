using Kai.Common.Data.DataStore;

namespace Kai.Title.Domain.UseCase.Interface
{
    public interface IStageDataUseCase
    {
        StageData GetStageData(int index);
    }
}