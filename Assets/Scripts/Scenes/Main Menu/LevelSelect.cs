using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
