using Common.Sound.BGM;
using Common.Sound.SE;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private BgmController bgmController = default;
        [SerializeField] private SeController seController = default;

        public override void InstallBindings()
        {
            #region Sound

            Container
                .Bind<BgmController>()
                .FromInstance(bgmController)
                .AsCached();

            Container
                .Bind<SeController>()
                .FromInstance(seController)
                .AsCached();

            #endregion
        }
    }
}