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
        private readonly IStepCountUseCase _stepCountUseCase;
        private readonly StepCountView _stepCountView;
        private readonly ILevelUseCase _levelUseCase;
        private readonly LevelView _levelView;
        private readonly IButtonContainerUseCase _buttonContainerUseCase;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, TransitionMaskView transitionMaskView,
            IStepCountUseCase stepCountUseCase, StepCountView stepCountView,
            ILevelUseCase levelUseCase, LevelView levelView, IButtonContainerUseCase buttonContainerUseCase)
        {
            _tokenSource = new CancellationTokenSource();
            _zenjectSceneLoader = zenjectSceneLoader;
            _transitionMaskView = transitionMaskView;
            _stepCountUseCase = stepCountUseCase;
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
            // シーン遷移中にボタンを押下させない
            _buttonContainerUseCase.ActivateButton(false, true);

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

            // トランジションが完了するまでボタンを押下させない
            _buttonContainerUseCase.ActivateButton(false);

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

            _buttonContainerUseCase.ActivateButton(true);
        }

        public void LoadResult()
        {
            LoadResultAsync(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadResultAsync(CancellationToken token)
        {
            _buttonContainerUseCase.ActivateButton(false, true);
            _levelView.ShowClear();
            _stepCountView.TweenCenter();
            await _transitionMaskView.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(SceneName.Ranking.ToString());

            _buttonContainerUseCase.ActivateButton(false);

            await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.LOAD_INTERVAL), cancellationToken: token);

            await _transitionMaskView.FadeOutAllAsync(token);
            _stepCountView.Hide();

            _buttonContainerUseCase.ActivateButton(true);
        }
    }
}