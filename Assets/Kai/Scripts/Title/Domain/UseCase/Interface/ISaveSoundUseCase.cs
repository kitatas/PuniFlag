namespace Kai.Title.Domain.UseCase.Interface
{
    public interface ISaveSoundUseCase
    {
        float bgmVolume { get; }
        void SaveBgmVolume(float bgmVolumeValue);
        float seVolume { get; }
        void SaveSeVolume(float seVolumeValue);
    }
}