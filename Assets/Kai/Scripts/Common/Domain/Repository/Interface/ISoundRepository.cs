using Common.Application;
using UnityEngine;

namespace Common.Domain.Repository.Interface
{
    public interface ISoundRepository
    {
        AudioClip FindBgm(BgmType bgmType);
        AudioClip FindSe(SeType seType);
    }
}