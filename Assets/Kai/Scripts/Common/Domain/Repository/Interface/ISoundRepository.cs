using Kai.Common.Application;
using UnityEngine;

namespace Kai.Common.Domain.Repository.Interface
{
    public interface ISoundRepository
    {
        AudioClip FindBgm(BgmType bgmType);
        AudioClip FindSe(SeType seType);
    }
}