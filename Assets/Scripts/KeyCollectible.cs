using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;
            transform.SetParent(other.transform);   // attach to player
            transform.localPosition = new Vector3(0.5f, 1f, 0f); // position on player
            KeyManager.hasKey = true;
        }
    }
}

