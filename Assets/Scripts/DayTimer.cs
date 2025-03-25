using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public Text text;
    public float seconds;


    void Start()
    {
        seconds = 0;
        //StartCoroutine(timer());
    }

    void Update()
    {
        dayTimer();
        // if(seconds == 180)
        // {
        //     // you win! screen here
        // }
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
        }
    }
    // private IEnumerator timer()
    // {
    //     text.text = "Day 1";
    //     while(seconds < 180)
    //     {
    //         yield return new WaitForSeconds(1f);
    //         seconds++;
    //         if(seconds == 60)
    //         {
    //             text.text = "Day 2";
    //         }
    //         else if(seconds == 120)
    //         {
               
    //             text.text = "Day 3";
    //         }
    //     }

    // }
}
