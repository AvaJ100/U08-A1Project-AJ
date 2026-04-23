using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    public void TakeDamage(int amount)
    {
        lives -= amount;

        if (lives <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}

