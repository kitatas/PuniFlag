using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using UniRx;
using UnityEngine;
using Zenject;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class ButtonSceneLoader : MonoBehaviour
    {
        [SerializeField] private GameType gameType = default;
        [SerializeField] private SceneName sceneName = default;
        [SerializeField] private LoadType loadType = default;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            var buttonAnimator = GetComponent<ButtonAnimator>();
            buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _sceneLoader.LoadScene(gameType, sceneName, loadType);
                    buttonAnimator.Play();
                })
                .AddTo(this);
        }
    }
}