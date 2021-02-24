using Common.View.Button;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Common.Transition
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class LoadButton : MonoBehaviour
    {
        [SerializeField] private SceneName sceneName = default;
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
                    _sceneLoader.LoadScene(sceneName);
                    _buttonAnimator.Play();
                })
                .AddTo(this);
        }
    }
}