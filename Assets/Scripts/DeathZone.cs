using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            other.GetComponent<Health>().TakeDamage(1000);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
