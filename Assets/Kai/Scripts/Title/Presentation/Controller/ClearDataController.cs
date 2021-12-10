using System.Collections.Generic;
using System.Linq;
using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using Kai.Title.Domain.UseCase.Interface;
using Kai.Title.Presentation.View;
using UnityEngine;
using Zenject;

namespace Kai.Title.Presentation.Controller
{
    public sealed class ClearDataController : MonoBehaviour
    {
        [SerializeField] private List<StageButtonView> stageButtonViews = default;
        [SerializeField] private GameObject red = default;
        [SerializeField] private GameObject green = default;

        [Inject]
        private void Construct(IStageDataUseCase stageDataUseCase, IClearDataUseCase clearDataUseCase, SceneLoader sceneLoader)
        {
            for (int i = 0; i < clearDataUseCase.clearData.Length; i++)
            {
                var index = i;
                var stageData = stageDataUseCase.GetStageData(index);
                var isClear = clearDataUseCase.clearData[index];
                stageButtonViews[index].Init(index + 1, stageData.GetButtonTexture(isClear), () =>
                {
                    sceneLoader.LoadScene(GameType.FreePlay, SceneName.Main, LoadType.Direct, index);
                });
            }

            // FreePlay全クリア
            var isFreePlayClear = clearDataUseCase.clearData
                .Count(x => x)
                .Equals(GameConfig.FREE_PLAY_COUNT);
            red.SetActive(isFreePlayClear);

            // ScoreAttack全クリア
            var isScoreAttackClear = clearDataUseCase.rankData
                .Count(x => x)
                .Equals(GameConfig.STAGE_COUNT);
            green.SetActive(isScoreAttackClear);
        }
    }
}