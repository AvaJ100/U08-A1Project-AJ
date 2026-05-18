using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.AddScore(value);

            Destroy(gameObject);
        }
    }
}