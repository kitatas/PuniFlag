using Common.Domain.Repository;
using Common.Domain.UseCase;
using Common.Presentation.Controller;
using Common.Presentation.View;
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
        [SerializeField] private TransitionMaskView transitionMaskView = default;
        [SerializeField] private StepCountView stepCountView = default;
        [SerializeField] private LevelView levelView = default;

        public override void InstallBindings()
        {
            #region Domain

            #region Repository

            Container
                .BindInterfacesTo<SoundRepository>()
                .AsCached();

            #endregion

            #region UseCase

            Container
                .BindInterfacesTo<SoundUseCase>()
                .AsCached();

            #endregion

            #endregion


            #region Presentation

            #region Controller

            Container
                .Bind<BgmController>()
                .FromInstance(bgmController)
                .AsCached();

            Container
                .Bind<SeController>()
                .FromInstance(seController)
                .AsCached();

            #endregion

            #endregion


            #region Transition

            Container
                .Bind<SceneLoader>()
                .AsCached();

            Container
                .Bind<TransitionMaskView>()
                .FromInstance(transitionMaskView)
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