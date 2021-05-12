using Game.Factory.Interface;
using Game.Presentation.View;
using UnityEngine;
using Zenject;

namespace Game.Factory
{
    public sealed class StageObjectFactory : IStageObjectFactory
    {
        private StageView _stageView;

        [Inject]
        private void Construct(StageView stageView)
        {
            _stageView = stageView;
        }

        public void GenerateStageObject(GameObject stageObject, Vector2 position, Quaternion quaternion)
        {
            var instance = Object.Instantiate(stageObject, position, quaternion);
            instance.transform.SetParent(_stageView.transform);
        }
    }
}