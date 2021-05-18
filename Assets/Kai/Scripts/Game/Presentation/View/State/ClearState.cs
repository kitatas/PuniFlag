using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using Kai.Game.Application;
using Zenject;

namespace Kai.Game.Presentation.View.State
{
    public sealed class ClearState : BaseState
    {
        private GameType _gameType;
        private SeController _seController;
        private SceneLoader _sceneLoader;
        private ClearView _clearView;

        [Inject]
        private void Construct(GameType gameType, SeController seController, SceneLoader sceneLoader, ClearView clearView)
        {
            _gameType = gameType;
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

            switch (_gameType)
            {
                case GameType.ScoreAttack:
                    _sceneLoader.LoadScene(_gameType, SceneName.Main, LoadType.Next);
                    break;
                case GameType.FreePlay:
                    break;
                case GameType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return GameState.None;
        }
    }
}