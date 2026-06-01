using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void RestartButton()
    {
        SceneManager.LoadScene("TestLevel");
    }
}
