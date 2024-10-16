using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadMotel : MonoBehaviour
{
    public void MotelSelected()
    {
        SceneManager.LoadScene("Level_Motel");
    }
}
