using UnityEngine;


public class SceneController : MonoBehaviour
{


    public static SceneController instance;
    public bool isStoveLoaded = false;

    private void Awake()
    {
        // If no instance exists, this becomes the instance and we're setting it to persist
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            // If another instance already exists, destroy the new one to enforce singleton
            Destroy(gameObject);
        }
    }
}