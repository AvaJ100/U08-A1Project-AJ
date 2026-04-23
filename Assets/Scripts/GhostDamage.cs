using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public int damage = 1;
    public PlayerHealth playerHealth;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Player object collided but has no PlayerHealth component.");
            }
        }
    }
}
