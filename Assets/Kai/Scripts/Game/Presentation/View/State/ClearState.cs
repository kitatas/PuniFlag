using System;
using System.Threading;
using Common.Application;
using Common.Presentation.Controller;
using Common.Transition;
using Cysharp.Threading.Tasks;
using Game.Application;
using Zenject;

namespace Game.Presentation.View.State
{
    public sealed class ClearState : BaseState
    {
        private SeController _seController;
        private SceneLoader _sceneLoader;
        private ClearView _clearView;

        [Inject]
        private void Construct(SeController seController, SceneLoader sceneLoader, ClearView clearView)
        {
            _seController = seController;
            _sceneLoader = sceneLoader;
            _clearView = clearView;
        }

        public override GameState GetState() => GameState.Clear;

        public override UniTask InitAsync(CancellationToken token)
        {
            _clearView.Init();
            return base.InitAsync(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _seController.PlaySe(SeType.StageClear);

            await _clearView.ShowAsync(token);

            await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.LOAD_INTERVAL), cancellationToken: token);

            _sceneLoader.LoadScene(SceneName.Main, LoadType.Next);

            return GameState.None;
        }
    }
}