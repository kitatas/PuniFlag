using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Common.Application;
using Kai.Common.Domain.UseCase.Interface;
using Kai.Common.Presentation.View;
using UnityEngine.SceneManagement;
using Zenject;

namespace Kai.Common.Presentation.Controller
{
    public sealed class SceneLoader
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private readonly TransitionMaskView _transitionMaskView;
        private readonly StepCountView _stepCountView;
        private readonly ILevelUseCase _levelUseCase;
        private readonly LevelView _levelView;
        private readonly IButtonContainerUseCase _buttonContainerUseCase;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, TransitionMaskView transitionMaskView,
            StepCountView stepCountView,
            ILevelUseCase levelUseCase, LevelView levelView, IButtonContainerUseCase buttonContainerUseCase)
        {
            _tokenSource = new CancellationTokenSource();
            _zenjectSceneLoader = zenjectSceneLoader;
            _transitionMaskView = transitionMaskView;
            _stepCountView = stepCountView;
            _levelUseCase = levelUseCase;
            _levelView = levelView;
            _buttonContainerUseCase = buttonContainerUseCase;
        }

        ~SceneLoader()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void LoadScene(GameType gameType, SceneName sceneName, LoadType loadType)
        {
            switch (gameType)
            {
                case GameType.ScoreAttack:
                    LoadScoreAttack(sceneName, loadType);
                    break;
                case GameType.FreePlay:
                    break;
                case GameType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
            }
        }

        private void LoadScoreAttack(SceneName sceneName, LoadType loadType)
        {
            switch (loadType)
            {
                case LoadType.Direct:
                case LoadType.Reload:
                {
                    var level = _levelUseCase.GetLevel();
                    LoadSceneAsync(GameType.ScoreAttack, sceneName, level, _tokenSource.Token).Forget();
                    break;
                }
                case LoadType.Next:
                {
                    _levelUseCase.CountUp();
                    var level = _levelUseCase.GetLevel();
                    if (level < GameConfig.STAGE_COUNT)
                    {
                        LoadSceneAsync(GameType.ScoreAttack, sceneName, level, _tokenSource.Token).Forget();
                    }
                    else
                    {
                        LoadSceneAsync(GameType.ScoreAttack, SceneName.Ranking, level, _tokenSource.Token).Forget();
                    }
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(loadType), loadType, null);
            }
        }

        private async UniTaskVoid LoadSceneAsync(GameType gameType, SceneName sceneName, int level, CancellationToken token)
        {
            // シーン遷移中にボタンを押下させない
            _buttonContainerUseCase.ActivateButton(false, true);

            OnBeginTransition(sceneName);

            await _transitionMaskView.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Single, container =>
            {
                container.BindInstance(level);
                container.BindInstance(gameType);
            });

            // トランジションが完了するまでボタンを押下させない
            _buttonContainerUseCase.ActivateButton(false);

            await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.LOAD_INTERVAL), cancellationToken: token);

            await OnEndTransitionAsync(sceneName, token);

            _buttonContainerUseCase.ActivateButton(true);
        }

        private void OnBeginTransition(SceneName sceneName)
        {
            switch (sceneName)
            {
                case SceneName.Title:
                    _levelView.Hide();
                    break;
                case SceneName.Main:
                    _stepCountView.TweenCenter();
                    break;
                case SceneName.Ranking:
                    _levelView.ShowClear();
                    _stepCountView.TweenCenter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null);
            }
        }

        private async UniTask OnEndTransitionAsync(SceneName sceneName, CancellationToken token)
        {
            switch (sceneName)
            {
                case SceneName.Title:
                    _stepCountView.Hide(CommonViewConfig.UI_ANIMATION_TIME);
                    await _transitionMaskView.FadeOutAllAsync(token);
                    _levelUseCase.ResetLevel();
                    _levelView.Show();
                    break;
                case SceneName.Main:
                    _stepCountView.TweenTop();
                    await _transitionMaskView.FadeOutAsync(token);
                    break;
                case SceneName.Ranking:
                    await _transitionMaskView.FadeOutAllAsync(token);
                    _stepCountView.Hide();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null);
            }
        }
    }
}