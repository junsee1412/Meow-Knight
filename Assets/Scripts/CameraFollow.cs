using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void LateUpdate()
    {
        Vector3 desiredPositon = target.position + offset;
        Vector3 smoothPositon = Vector3.Lerp(transform.position, desiredPositon, smoothSpeed);
        transform.position = smoothPositon;
    }
}
