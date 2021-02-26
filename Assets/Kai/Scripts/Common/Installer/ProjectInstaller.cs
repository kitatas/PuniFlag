using Common.Sound.BGM;
using Common.Sound.SE;
using Common.Transition;
using Game.Stage.Level;
using Game.StepCount;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private BgmController bgmController = default;
        [SerializeField] private SeController seController = default;
        [SerializeField] private TransitionMask transitionMask = default;
        [SerializeField] private StepCountView stepCountView = default;
        [SerializeField] private LevelView levelView = default;

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

            #region MoveCount

            Container
                .Bind<StepCountModel>()
                .AsCached();

            Container
                .Bind<StepCountView>()
                .FromInstance(stepCountView)
                .AsCached();

            Container
                .Bind<StepCountPresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region Level

            Container
                .Bind<LevelModel>()
                .AsCached();

            Container
                .Bind<LevelView>()
                .FromInstance(levelView)
                .AsCached();

            Container
                .Bind<LevelPresenter>()
                .AsCached()
                .NonLazy();

            #endregion
        }
    }
}