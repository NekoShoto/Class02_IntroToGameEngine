using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
#if UNITY_EDITOR
            if (instance == null)
            {
                Debug.LogWarning("Singleton doesnt exist");
            }
#endif
            return instance;
        }
    }


    private void InitSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Awake()
    {
        InitSingleton();
    }
}
