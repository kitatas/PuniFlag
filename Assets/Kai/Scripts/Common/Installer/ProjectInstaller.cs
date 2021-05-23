using Kai.Common.Data.Container;
using Kai.Common.Data.Entity;
using Kai.Common.Domain.Model;
using Kai.Common.Domain.Repository;
using Kai.Common.Domain.UseCase;
using Kai.Common.Presentation.Controller;
using Kai.Common.Presentation.Presenter;
using Kai.Common.Presentation.View;
using UnityEngine;
using Zenject;

namespace Kai.Common.Installer
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
            #region Container

            Container
                .BindInterfacesTo<ButtonContainer>()
                .AsCached();

            #endregion

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
                .BindInterfacesTo<SaveDataRepository>()
                .AsCached();

            Container
                .BindInterfacesTo<SoundRepository>()
                .AsCached();

            #endregion

            #region UseCase

            Container
                .BindInterfacesTo<ContainerUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<LevelUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<SaveDataUseCase>()
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