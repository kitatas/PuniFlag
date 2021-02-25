using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.StepCount;
using Zenject;

namespace Common.Transition
{
    public sealed class SceneLoader
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private readonly TransitionMask _transitionMask;
        private readonly StepCountPresenter _stepCountPresenter;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, TransitionMask transitionMask,
            StepCountPresenter stepCountPresenter)
        {
            _tokenSource = new CancellationTokenSource();
            _zenjectSceneLoader = zenjectSceneLoader;
            _transitionMask = transitionMask;
            _stepCountPresenter = stepCountPresenter;
        }

        ~SceneLoader()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void LoadScene(SceneName sceneName)
        {
            LoadSceneAsync(sceneName, _tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadSceneAsync(SceneName sceneName, CancellationToken token)
        {
            _stepCountPresenter.TweenCenter();
            await _transitionMask.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(sceneName.ToString());

            await UniTask.Delay(TimeSpan.FromSeconds(Const.FADE_TIME), cancellationToken: token);

            switch (sceneName)
            {
                case SceneName.Title:
                    await _transitionMask.FadeOutAllAsync(token);
                    _stepCountPresenter.ResetCount();
                    break;
                case SceneName.Main:
                    _stepCountPresenter.TweenBottom();
                    await _transitionMask.FadeOutAsync(token);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null);
            }
        }
    }
}