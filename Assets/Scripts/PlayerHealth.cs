using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 3;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        GameManager.instance.TakeDamage(damage);
    }
}