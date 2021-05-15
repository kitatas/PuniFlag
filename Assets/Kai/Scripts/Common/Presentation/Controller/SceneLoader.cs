using System;
using System.Threading;
using Common.Application;
using Common.Domain.Model;
using Common.Domain.UseCase.Interface;
using Common.Presentation.View;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Presentation.Controller
{
    public sealed class SceneLoader
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private readonly TransitionMaskView _transitionMaskView;
        private readonly IStepCountUseCase _stepCountUseCase;
        private readonly StepCountView _stepCountView;
        private readonly ILevelUseCase _levelUseCase;
        private readonly LevelView _levelView;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, TransitionMaskView transitionMaskView,
            IStepCountUseCase stepCountUseCase, StepCountView stepCountView, 
            ILevelUseCase levelUseCase, LevelView levelView)
        {
            _tokenSource = new CancellationTokenSource();
            _zenjectSceneLoader = zenjectSceneLoader;
            _transitionMaskView = transitionMaskView;
            _stepCountUseCase = stepCountUseCase;
            _stepCountView = stepCountView;
            _levelUseCase = levelUseCase;
            _levelView = levelView;
        }

        ~SceneLoader()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void LoadScene(SceneName sceneName, LoadType loadType)
        {
            switch (loadType)
            {
                case LoadType.Direct:
                    LoadScene(sceneName);
                    break;
                case LoadType.Next:
                    _levelUseCase.CountUp();
                    var level = _levelUseCase.GetLevel();
                    if (level < GameConfig.STAGE_COUNT)
                    {
                        LoadScene(sceneName, level);
                    }
                    else
                    {
                        LoadResult();
                    }
                    break;
                case LoadType.Reload:
                    _stepCountUseCase.CountUp();
                    LoadScene(sceneName, _levelUseCase.GetLevel());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void LoadScene(SceneName sceneName, int level = 0)
        {
            LoadSceneAsync(sceneName, level, _tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadSceneAsync(SceneName sceneName, int level, CancellationToken token)
        {
            if (sceneName == SceneName.Title)
            {
                _levelView.Hide();
            }
            else
            {
                _stepCountView.TweenCenter();
            }

            await _transitionMaskView.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Single, container =>
            {
                container.BindInstance(level);
            });

            await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.LOAD_INTERVAL), cancellationToken: token);

            switch (sceneName)
            {
                case SceneName.Title:
                    _stepCountView.Hide(CommonViewConfig.UI_ANIMATION_TIME);
                    await _transitionMaskView.FadeOutAllAsync(token);
                    _stepCountUseCase.ResetStepCount();
                    _levelUseCase.ResetLevel();
                    _levelView.Show();
                    break;
                case SceneName.Main:
                    _stepCountView.TweenTop();
                    await _transitionMaskView.FadeOutAsync(token);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null);
            }
        }

        public void LoadResult()
        {
            LoadResultAsync(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadResultAsync(CancellationToken token)
        {
            _levelView.ShowClear();
            _stepCountView.TweenCenter();
            await _transitionMaskView.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(SceneName.Ranking.ToString());

            await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.LOAD_INTERVAL), cancellationToken: token);

            await _transitionMaskView.FadeOutAllAsync(token);
            _stepCountView.Hide();
        }
    }
}