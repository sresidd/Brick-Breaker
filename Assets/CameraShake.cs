using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Camera cam;


    [Header("Camera Shake Properties")]
    [SerializeField] private float duration = .5f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private int vibration = 10;
    [SerializeField] private float randomness = 90f;
    [SerializeField] private bool snapping = false;
    [SerializeField] private bool fadeout = true;

    void Start(){
        if(cam == null)cam = Camera.main;
        GameEvents.current.OnCameraShake += Shake;
    }


    [ContextMenu("Call Camera Shake")]
    public void Shake(){
        cam.transform.DOShakePosition(duration, strength, vibration, randomness, snapping, fadeout);
    }
}
