using UnityEngine;
using UnityEngine.UI;

public class FollowEnemy : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
