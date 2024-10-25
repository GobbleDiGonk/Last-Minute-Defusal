using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevelManager : MonoBehaviour
{
    int sceneIndex;
    int sceneToOpen;

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (!PlayerPrefs.HasKey("previousScene" + sceneIndex)) //checks for the scene the player was in previously
        {
            PlayerPrefs.SetInt("previousScene" + sceneIndex, sceneIndex);
        }

        sceneToOpen = PlayerPrefs.GetInt("previousScene" + sceneIndex);
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}
