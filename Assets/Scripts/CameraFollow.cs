using UnityEngine;
using EZCameraShake;

public class CameraFollow : MonoBehaviour
{
    [Header("Shake Controls")]
    public float magnitude = 0.5f;
    public float roughness = 0.5f;
    public float fadeInTime = 5f;

    [Header("Player")]
    public Transform target;

    void LateUpdate ()
    {
        CameraShaker.Instance.StartShake(magnitude, roughness, fadeInTime);
    }
}
