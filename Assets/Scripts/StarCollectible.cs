using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(1);

            Destroy(gameObject);
        }
    }
}