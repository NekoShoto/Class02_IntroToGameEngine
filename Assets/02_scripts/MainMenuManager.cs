using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string sceneToLoad = "";

    AudioSource audioSrc;


    // Start is called before the first frame update
    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
