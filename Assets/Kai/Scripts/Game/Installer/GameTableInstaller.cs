using Game.Stage;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    [CreateAssetMenu(fileName = "GameTableInstaller", menuName = "Installers/GameTableInstaller")]
    public sealed class GameTableInstaller : ScriptableObjectInstaller<GameTableInstaller>
    {
        [SerializeField] private StageDataTable stageDataTable = default;

        public override void InstallBindings()
        {
            Container
                .Bind<StageDataTable>()
                .FromInstance(stageDataTable)
                .AsCached();
        }
    }
}