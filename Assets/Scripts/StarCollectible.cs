using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Star collected!");
            StarManager.instance.AddStar();
            Destroy(gameObject);
        }
    }
}

