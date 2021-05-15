using Common.Data.Entity;
using Common.Domain.Model;
using Common.Domain.Repository;
using Common.Domain.UseCase;
using Common.Presentation.Controller;
using Common.Presentation.Presenter;
using Common.Presentation.View;
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
            #region Entity

            Container
                .BindInterfacesTo<LevelEntity>()
                .AsCached();

            Container
                .BindInterfacesTo<StepCountEntity>()
                .AsCached();

            #endregion

            #region Model

            Container
                .BindInterfacesTo<LevelModel>()
                .AsCached();

            Container
                .BindInterfacesTo<StepCountModel>()
                .AsCached();

            #endregion

            #region Repository

            Container
                .BindInterfacesTo<SoundRepository>()
                .AsCached();

            #endregion

            #region UseCase

            Container
                .BindInterfacesTo<LevelUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<SoundUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<StepCountUseCase>()
                .AsCached();

            #endregion

            #region Controller

            Container
                .Bind<BgmController>()
                .FromInstance(bgmController)
                .AsCached();

            Container
                .Bind<SeController>()
                .FromInstance(seController)
                .AsCached();

            Container
                .Bind<SceneLoader>()
                .AsCached();

            #endregion

            #region Presenter

            Container
                .Bind<LevelPresenter>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<StepCountPresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<TransitionMaskView>()
                .FromInstance(transitionMaskView)
                .AsCached();

            Container
                .Bind<LevelView>()
                .FromInstance(levelView)
                .AsCached();

            Container
                .Bind<StepCountView>()
                .FromInstance(stepCountView)
                .AsCached();

            #endregion
        }
    }
}