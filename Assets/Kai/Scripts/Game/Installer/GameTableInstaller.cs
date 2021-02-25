using Game.Stage;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    [CreateAssetMenu(fileName = "GameTableInstaller", menuName = "Installers/GameTableInstaller")]
    public sealed class GameTableInstaller : ScriptableObjectInstaller<GameTableInstaller>
    {
        [SerializeField] private StageData stageData = default;

        public override void InstallBindings()
        {
            Container
                .Bind<StageData>()
                .FromInstance(stageData)
                .AsCached();
        }
    }
}