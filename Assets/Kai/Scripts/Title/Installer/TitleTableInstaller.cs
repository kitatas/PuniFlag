using Kai.Common.Data.DataStore;
using UnityEngine;
using Zenject;

namespace Kai.Title.Installer
{
    [CreateAssetMenu(fileName = "TitleTableInstaller", menuName = "Installers/TitleTableInstaller")]
    public sealed class TitleTableInstaller : ScriptableObjectInstaller<TitleTableInstaller>
    {
        [SerializeField] private StageDataTable freePlayStageDataTable = default;

        public override void InstallBindings()
        {
            Container
                .Bind<StageDataTable>()
                .FromInstance(freePlayStageDataTable)
                .AsCached();
        }
    }
}