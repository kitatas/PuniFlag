using UnityEngine;

namespace Game.Factory.Interface
{
    public interface IStageObjectFactory
    {
        GameObject GenerateStageObject(GameObject stageObject, Vector2 position, Quaternion quaternion);
    }
}