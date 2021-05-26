using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Zenject;

namespace Kai.Game.Presentation.View.State
{
    public sealed class ClearState : BaseState
    {
        private GameType _gameType;
        private SeController _seController;
        private SceneLoader _sceneLoader;
        private ClearView _clearView;
        private FreePlayNextView _freePlayNextView;
        private IClearDataUseCase _clearDataUseCase;

        [Inject]
        private void Construct(GameType gameType, SeController seController, SceneLoader sceneLoader,
            ClearView clearView, FreePlayNextView freePlayNextView, IClearDataUseCase clearDataUseCase)
        {
            _gameType = gameType;
            _seController = seController;
            _sceneLoader = sceneLoader;
            _clearView = clearView;
            _freePlayNextView = freePlayNextView;
            _clearDataUseCase = clearDataUseCase;
        }

        public override GameState GetState() => GameState.Clear;

        public override UniTask InitAsync(CancellationToken token)
        {
            _clearView.Init();
            _freePlayNextView.Init();
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
                    _clearDataUseCase.SaveFreePlayClearData();
                    _freePlayNextView.ShowAsync(token).Forget();
                    break;
                case GameType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return GameState.None;
        }
    }
}