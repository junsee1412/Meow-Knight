using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject obj; // chi lay tags cua obj :v
    public int damage = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == obj.tag)
        {
            other.GetComponent<Health>().TakeDamage(damage);
            // Debug.Log($"Attack at: {Time.time}");
        }
    }
}
