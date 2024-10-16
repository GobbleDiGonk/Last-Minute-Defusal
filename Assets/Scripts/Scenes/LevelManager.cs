using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
