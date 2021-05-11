using Common.Application;
using UnityEngine;

namespace Common.Domain.UseCase.Interface
{
    public interface IBgmUseCase
    {
        AudioClip GetBgmClip(BgmType bgmType);
    }
}