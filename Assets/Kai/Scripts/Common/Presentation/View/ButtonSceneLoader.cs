using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class ButtonSceneLoader : MonoBehaviour
    {
        [SerializeField] private GameType gameType = default;
        [SerializeField] private SceneName sceneName = default;
        [SerializeField] private LoadType loadType = default;

        private SceneLoader _sceneLoader;
        private ButtonAnimator _buttonAnimator;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _buttonAnimator = GetComponent<ButtonAnimator>();
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _sceneLoader.LoadScene(gameType, sceneName, loadType);
                    _buttonAnimator.Play();
                })
                .AddTo(this);
        }
    }
}