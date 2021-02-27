using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Stage.Level;
using Game.StepCount;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Transition
{
    public sealed class SceneLoader
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private readonly TransitionMask _transitionMask;
        private readonly StepCountModel _stepCountModel;
        private readonly StepCountView _stepCountView;
        private readonly LevelModel _levelModel;
        private readonly LevelView _levelView;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, TransitionMask transitionMask,
            StepCountModel stepCountModel, StepCountView stepCountView, LevelModel levelModel, LevelView levelView)
        {
            _tokenSource = new CancellationTokenSource();
            _zenjectSceneLoader = zenjectSceneLoader;
            _transitionMask = transitionMask;
            _stepCountModel = stepCountModel;
            _stepCountView = stepCountView;
            _levelModel = levelModel;
            _levelView = levelView;
        }

        ~SceneLoader()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void LoadScene(SceneName sceneName, int level = 0)
        {
            LoadSceneAsync(sceneName, level, _tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadSceneAsync(SceneName sceneName, int level, CancellationToken token)
        {
            _stepCountView.TweenCenter();
            await _transitionMask.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Single, container =>
            {
                container.BindInstance(level);
            });

            await UniTask.Delay(TimeSpan.FromSeconds(Const.INTERVAL), cancellationToken: token);

            switch (sceneName)
            {
                case SceneName.Title:
                    await _transitionMask.FadeOutAllAsync(token);
                    _stepCountModel.ResetStepCount();
                    _levelModel.ResetLevel();
                    break;
                case SceneName.Main:
                    _stepCountView.TweenBottom();
                    await _transitionMask.FadeOutAsync(token);
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
            _levelView.Hide();
            _stepCountView.TweenCenter();
            await _transitionMask.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(SceneName.Ranking.ToString());

            await UniTask.Delay(TimeSpan.FromSeconds(Const.INTERVAL), cancellationToken: token);

            await _transitionMask.FadeOutAllAsync(token);
        }
    }
}