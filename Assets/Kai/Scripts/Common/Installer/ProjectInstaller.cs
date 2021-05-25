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
                .AsSingle();

            #endregion

            #region Entity

            Container
                .BindInterfacesTo<LevelEntity>()
                .AsSingle();

            Container
                .BindInterfacesTo<StepCountEntity>()
                .AsSingle();

            #endregion

            #region Model

            Container
                .BindInterfacesTo<LevelModel>()
                .AsSingle();

            Container
                .BindInterfacesTo<StepCountModel>()
                .AsSingle();

            #endregion

            #region Repository

            Container
                .BindInterfacesTo<LanguageRepository>()
                .AsSingle();

            Container
                .BindInterfacesTo<SaveDataRepository>()
                .AsSingle();

            Container
                .BindInterfacesTo<SoundRepository>()
                .AsSingle();

            #endregion

            #region UseCase

            Container
                .BindInterfacesTo<ContainerUseCase>()
                .AsSingle();

            Container
                .BindInterfacesTo<LevelUseCase>()
                .AsSingle();

            Container
                .BindInterfacesTo<SaveDataUseCase>()
                .AsSingle();

            Container
                .BindInterfacesTo<SoundUseCase>()
                .AsSingle();

            Container
                .BindInterfacesTo<StepCountUseCase>()
                .AsSingle();

            #endregion

            #region Controller

            Container
                .Bind<BgmController>()
                .FromInstance(bgmController)
                .AsSingle();

            Container
                .Bind<SeController>()
                .FromInstance(seController)
                .AsSingle();

            Container
                .Bind<SceneLoader>()
                .AsSingle();

            #endregion

            #region Presenter

            Container
                .Bind<LevelPresenter>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<StepCountPresenter>()
                .AsSingle()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<TransitionMaskView>()
                .FromInstance(transitionMaskView)
                .AsSingle();

            Container
                .Bind<LevelView>()
                .FromInstance(levelView)
                .AsSingle();

            Container
                .Bind<StepCountView>()
                .FromInstance(stepCountView)
                .AsSingle();

            #endregion
        }
    }
}