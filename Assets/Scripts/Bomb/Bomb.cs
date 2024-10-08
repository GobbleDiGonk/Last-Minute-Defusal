using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public TextMeshProUGUI bombTimer;
    [SerializeField] float remainingTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the time is greater than zero and ticks it down
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        } else if (remainingTime < 0) 
        {
            //stops the timer once it hits zero
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        bombTimer.text = string.Format("{0:00}, {1:00}", minutes, seconds);
    }
}
