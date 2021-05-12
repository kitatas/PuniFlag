using Game.Application;
using Game.Data.DataStore;
using Game.Domain.Repository.Interface;
using Game.Presentation.View;
using UnityEngine;

namespace Game.Domain.Repository
{
    public sealed class StageRepository : IStageRepository
    {
        private readonly StageDataTable _stageDataTable;
        private readonly StageObjectTable _stageObjectTable;

        public StageRepository(StageDataTable stageDataTable, StageObjectTable stageObjectTable)
        {
            _stageDataTable = stageDataTable;
            _stageObjectTable = stageObjectTable;
        }

        public StageObjectView GetStageObject(StageObjectType type, ColorType color)
        {
            return _stageObjectTable.stageObjectDataList
                .Find(x => x.type == type && x.color == color)
                .stageObject;
        }

        public TextAsset GetStageData(int stageLevel) => _stageDataTable.stageDataList[stageLevel];
    }
}