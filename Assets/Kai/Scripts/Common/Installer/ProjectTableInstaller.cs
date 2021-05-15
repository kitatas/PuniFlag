using Kai.Common.Data.DataStore;
using UnityEngine;
using Zenject;

namespace Kai.Common.Installer
{
    [CreateAssetMenu(fileName = "ProjectTableInstaller", menuName = "Installers/ProjectTableInstaller")]
    public sealed class ProjectTableInstaller : ScriptableObjectInstaller<ProjectTableInstaller>
    {
        [SerializeField] private BgmTable bgmTable = default;
        [SerializeField] private SeTable seTable = default;

        public override void InstallBindings()
        {
            #region Data

            #region DataStore

            Container
                .Bind<BgmTable>()
                .FromInstance(bgmTable)
                .AsCached();

            Container
                .Bind<SeTable>()
                .FromInstance(seTable)
                .AsCached();

            #endregion

            #endregion
        }
    }
}