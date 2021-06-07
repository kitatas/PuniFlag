using System;
using Kai.Common.Application;
using Kai.Game.Data.DataStore;
using UnityEngine;
using Zenject;

namespace Kai.Game.Installer
{
    [CreateAssetMenu(fileName = "GameTableInstaller", menuName = "Installers/GameTableInstaller")]
    public sealed class GameTableInstaller : ScriptableObjectInstaller<GameTableInstaller>
    {
        private StageDataTable _bindStageDataTable;
        [SerializeField] private StageDataTable scoreAttackStageDataTable = default;
        [SerializeField] private StageDataTable freePlayStageDataTable = default;
        [SerializeField] private StageObjectTable stageObjectTable = default;

        [Inject]
        private void Construct(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.ScoreAttack:
                    _bindStageDataTable = scoreAttackStageDataTable;
                    break;
                case GameType.FreePlay:
                    _bindStageDataTable = freePlayStageDataTable;
                    break;
                case GameType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
            }
        }

        public override void InstallBindings()
        {
            #region DataStore

            Container
                .Bind<StageDataTable>()
                .FromInstance(_bindStageDataTable)
                .AsCached();

            Container
                .Bind<StageObjectTable>()
                .FromInstance(stageObjectTable)
                .AsCached();

            #endregion
        }
    }
}