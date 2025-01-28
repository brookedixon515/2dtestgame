using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeBar : MonoBehaviour
{
    bool isInside;
    int freezeprogress;
    static bool freezing;

    float lastFreezeProgressTime;   //The last time freeze progress was applied.
    float freezeProgressFrequency = 1f;  //How often freeze progress should be applied.

    float lastFreezeReduceTime;   //The last time freeze reduction was applied.
    float freezeReduceFrequency = 2f;  //How often freeze reduction should be applied.

    void Start()
    {
        freezeprogress = 0;
        isInside = false;
    }

    void Update()
    {
        if(isInside == false && freezeprogress <= 100 && Time.time >= lastFreezeProgressTime + freezeProgressFrequency)
        {
            lastFreezeProgressTime = Time.time;
            freezeprogress++;
        }
        
        if (isInside == true && freezeprogress >= 0 && Time.time >= lastFreezeReduceTime + freezeReduceFrequency)
        {
            lastFreezeReduceTime = Time.time;
            freezeprogress--;
        }

        if (freezeprogress == 100)
        {
            freezing = true;
        }

        if (freezeprogress <= 99)
        {
            freezing = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
        {
            if(col.gameObject.tag == "inside")
            {
                isInside = true;
            }
        }
}
