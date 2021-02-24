using System.Threading;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Common.Transition
{
    public sealed class SceneLoader
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private readonly TransitionMask _transitionMask;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, TransitionMask transitionMask)
        {
            _tokenSource = new CancellationTokenSource();
            _zenjectSceneLoader = zenjectSceneLoader;
            _transitionMask = transitionMask;
        }

        ~SceneLoader()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void LoadScene(SceneName sceneName)
        {
            LoadSceneAsync(sceneName.ToString(), _tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadSceneAsync(string sceneName, CancellationToken token)
        {
            await _transitionMask.FadeInAsync(token);

            await _zenjectSceneLoader.LoadSceneAsync(sceneName);

            await _transitionMask.FadeOutAsync(token);
        }
    }
}