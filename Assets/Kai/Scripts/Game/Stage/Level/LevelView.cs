using TMPro;
using UnityEngine;

namespace Game.Stage.Level
{
    public sealed class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stageText = default;
        [SerializeField] private TextMeshProUGUI stageLevelText = default;

        public void DisplayLevel(int level)
        {
            stageLevelText.text = $"Stage {level + 1:00}";
        }
    }
}