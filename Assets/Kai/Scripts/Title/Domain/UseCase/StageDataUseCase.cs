using Kai.Common.Data.DataStore;
using Kai.Title.Domain.Repository.Interface;
using Kai.Title.Domain.UseCase.Interface;

namespace Kai.Title.Domain.UseCase
{
    public sealed class StageDataUseCase : IStageDataUseCase
    {
        private readonly IStageDataRepository _stageDataRepository;

        public StageDataUseCase(IStageDataRepository stageDataRepository)
        {
            _stageDataRepository = stageDataRepository;
        }

        public StageData GetStageData(int index) => _stageDataRepository.GetStageData(index);
    }
}