using UnityEngine;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;  
    public int starCount = 0;            

    private void Awake()
    {
        instance = this;                 
    }

    public void AddStar()
    {
        starCount++;
        Debug.Log("Stars: " + starCount);
    }
}


