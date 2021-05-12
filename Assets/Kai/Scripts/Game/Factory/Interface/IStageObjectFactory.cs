using UnityEngine;

namespace Game.Factory.Interface
{
    public interface IStageObjectFactory
    {
        void GenerateStageObject(GameObject stageObject, Vector2 position, Quaternion quaternion);
    }
}