using System.Collections.Generic;
using Kai.Common.Data.DataStore;
using Kai.Game.Application;
using Kai.Game.Data.DataStore;
using Kai.Game.Data.Entity;
using Kai.Game.Domain.Repository.Interface;
using Kai.Game.Presentation.View;
using UnityEngine;

namespace Kai.Game.Domain.Repository
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

        public IEnumerable<StageObject> GetStageObjectDataList(int stageLevel)
        {
            var stageData = _stageDataTable.stageDataList[stageLevel].stageData;
            return JsonUtility.FromJson<StageDataEntity>(stageData.ToString()).stageObjects;
        }
    }
}