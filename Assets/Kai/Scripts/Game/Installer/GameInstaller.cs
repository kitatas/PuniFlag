using Kai.Game.Data.Container;
using Kai.Game.Data.Entity;
using Kai.Game.Domain.Model;
using Kai.Game.Domain.Repository;
using Kai.Game.Domain.UseCase;
using Kai.Game.Factory;
using Kai.Game.Presentation.Controller;
using Kai.Game.Presentation.Presenter;
using Kai.Game.Presentation.View;
using Kai.Game.Presentation.View.State;
using UnityEngine;
using Zenject;

namespace Kai.Game.Installer
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private ButtonController buttonController = default;
        [SerializeField] private StageView stageView = default;
        [SerializeField] private ClearView clearView = default;
        [SerializeField] private FreePlayNextView freePlayNextView = default;

        [SerializeField] private InputState inputState = default;
        [SerializeField] private JudgeState judgeState = default;
        [SerializeField] private ClearState clearState = default;


        public override void InstallBindings()
        {
            #region Container

            Container
                .BindInterfacesTo<PlayerContainer>()
                .AsCached();

            Container
                .BindInterfacesTo<FlagContainer>()
                .AsCached();

            #endregion

            #region Entity

            Container
                .BindInterfacesTo<GameStateEntity>()
                .AsCached();

            #endregion

            #region Model

            Container
                .BindInterfacesTo<GameStateModel>()
                .AsCached();

            #endregion

            #region Repository

            Container
                .BindInterfacesTo<StageRepository>()
                .AsCached();

            #endregion

            #region UseCase

            Container
                .BindInterfacesTo<GameStateUseCase>()
                .AsCached();

            Container
                .Bind<StageDataUseCase>()
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesTo<StageObjectContainerUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<InputUseCase>()
                .AsCached();

            #endregion

            #region Controller

            Container
                .Bind<ButtonController>()
                .FromInstance(buttonController)
                .AsCached();

            #endregion

            #region Presenter

            Container
                .Bind<StatePresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<InputState>()
                .FromInstance(inputState)
                .AsCached();

            Container
                .Bind<JudgeState>()
                .FromInstance(judgeState)
                .AsCached();

            Container
                .Bind<ClearState>()
                .FromInstance(clearState)
                .AsCached();

            Container
                .Bind<StageView>()
                .FromInstance(stageView)
                .AsCached();

            Container
                .Bind<ClearView>()
                .FromInstance(clearView)
                .AsCached();

            Container
                .Bind<FreePlayNextView>()
                .FromInstance(freePlayNextView)
                .AsCached();

            #endregion

            #region Factory

            Container
                .BindInterfacesTo<StageObjectFactory>()
                .AsCached();

            #endregion
        }
    }
}