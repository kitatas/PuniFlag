using System;
using System.Collections.Generic;
using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Data.Entity
{
    public sealed class StageDataEntity
    {
        public int targetCount;
        public List<StageObject> stageObjects;
    }

    [Serializable]
    public sealed class StageObject
    {
        public StageObjectType type;
        public ColorType color;
        public int x;
        public int y;
        public Vector2 position => new Vector2(x - 3, y - 3);
    }
}