using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public TextMeshProUGUI bombTimer;
    public UIManager uiManager;
    [SerializeField] float remainingTime = 60f;
    bool stopTimer;
    bool foundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foundPlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            stopTimer = true;
            SceneManager.LoadScene("MissionResults");
            SceneManager.UnloadScene("Level_Motel");
        }

        if(stopTimer == true)
        {
            return;
        }

        //checks if the time is greater than zero and ticks it down
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        } 
        
        else if (remainingTime < 0) 
        {
            //stops the timer once it hits zero
            remainingTime = 0;
            bombTimer.color = Color.red;
            SceneManager.LoadScene("MissionFailedMenu");
            SceneManager.UnloadScene("Level_Motel");
            
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        bombTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foundPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foundPlayer = false;
        }
    }
}
