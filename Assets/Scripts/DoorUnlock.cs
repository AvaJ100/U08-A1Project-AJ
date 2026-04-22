using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && KeyManager.hasKey)
        {
            Debug.Log("Door unlocked!");
            // Option 1: Destroy door
            Destroy(gameObject);
        }
    }
}

