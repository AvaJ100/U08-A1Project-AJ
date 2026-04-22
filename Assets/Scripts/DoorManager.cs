using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && KeyManager.hasKey)
        {
            Debug.Log("Door unlocked!");
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (collision.CompareTag("Player") && !KeyManager.hasKey)
        {
            Debug.Log("Door is locked. You need the key.");
        }
    }
}
