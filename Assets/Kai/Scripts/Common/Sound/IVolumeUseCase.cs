namespace Common.Sound
{
    public interface IVolumeUseCase
    {
        float GetVolume();
        void SetVolume(float value);
    }
}