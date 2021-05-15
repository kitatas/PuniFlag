using Kai.Common.Application;
using UnityEngine;

namespace Kai.Common.Domain.UseCase.Interface
{
    public interface IBgmUseCase
    {
        AudioClip GetBgmClip(BgmType bgmType);
    }
}