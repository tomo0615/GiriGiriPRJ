using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private bool isShaking;

    public void ShakeCamera(float time)
    {
        if (isShaking) return;
        isShaking = true;

        transform.DOShakePosition(time)
            .OnComplete(() =>
            {
                isShaking = false;
            });
    }
}
