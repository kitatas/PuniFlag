using Game.Data.DataStore;
using Game.Stage;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    [CreateAssetMenu(fileName = "GameTableInstaller", menuName = "Installers/GameTableInstaller")]
    public sealed class GameTableInstaller : ScriptableObjectInstaller<GameTableInstaller>
    {
        [SerializeField] private StageDataTable stageDataTable = default;
        [SerializeField] private StageObjectTable stageObjectTable = default;

        public override void InstallBindings()
        {
            #region Data

            #region DataStore

            Container
                .Bind<StageDataTable>()
                .FromInstance(stageDataTable)
                .AsCached();
            
            Container
                .Bind<StageObjectTable>()
                .FromInstance(stageObjectTable)
                .AsCached();

            #endregion

            #endregion
        }
    }
}