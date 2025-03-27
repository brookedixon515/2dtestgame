using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public Text text;
    public float seconds;
    public GameObject winmenu;


    void Start()
    {
        seconds = 0;
    }

    void Update()
    {
        dayTimer();
    }

    private void dayTimer()
    {
        text.text = "Day 1";
        if(seconds < 180f)
        {
            seconds += 1f * Time.deltaTime;
            if(seconds < 60f) text.text = "Day 1";
            else if(seconds < 120f && seconds > 60f)
                text.text = "Day 2";
            else if(seconds > 120f && seconds < 180f)
                text.text = "Day 3";
        }
        else
        {
            // Win screen here
             winmenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
