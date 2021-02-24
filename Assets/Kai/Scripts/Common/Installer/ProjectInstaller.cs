using Common.Sound.BGM;
using Common.Sound.SE;
using Common.Transition;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private BgmController bgmController = default;
        [SerializeField] private SeController seController = default;
        [SerializeField] private TransitionMask transitionMask = default;

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

            #region Transition

            Container
                .Bind<SceneLoader>()
                .AsCached();

            Container
                .Bind<TransitionMask>()
                .FromInstance(transitionMask)
                .AsCached();

            #endregion
        }
    }
}