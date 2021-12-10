using Kai.Common.Data.DataStore;

namespace Kai.Title.Domain.Repository.Interface
{
    public interface IStageDataRepository
    {
        StageData GetStageData(int index);
    }
}