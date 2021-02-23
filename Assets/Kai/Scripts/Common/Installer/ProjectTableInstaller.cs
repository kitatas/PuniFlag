using Common.Sound.BGM;
using Common.Sound.SE;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    [CreateAssetMenu(fileName = "ProjectTableInstaller", menuName = "Installers/ProjectTableInstaller")]
    public sealed class ProjectTableInstaller : ScriptableObjectInstaller<ProjectTableInstaller>
    {
        [SerializeField] private BgmTable bgmTable = default;
        [SerializeField] private SeTable seTable = default;

        public override void InstallBindings()
        {
            #region Sound

            Container
                .Bind<BgmTable>()
                .FromInstance(bgmTable)
                .AsCached();

            Container
                .Bind<SeTable>()
                .FromInstance(seTable)
                .AsCached();

            #endregion
        }
    }
}