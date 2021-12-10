using Kai.Common.Data.DataStore;
using Kai.Title.Domain.Repository.Interface;

namespace Kai.Title.Domain.Repository
{
    public sealed class StageDataRepository : IStageDataRepository
    {
        private readonly StageDataTable _stageDataTable;

        public StageDataRepository(StageDataTable stageDataTable)
        {
            _stageDataTable = stageDataTable;
        }

        public StageData GetStageData(int index) => _stageDataTable.stageDataList[index];
    }
}