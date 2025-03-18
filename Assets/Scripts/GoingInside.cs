using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingInside : MonoBehaviour
{
    public GameObject iglootop;
    void OnTriggerStay2D (Collider2D other)
    {
        iglootop.SetActive(false);
    }
   void OnTriggerExit2D (Collider2D other)
    {
        iglootop.SetActive(true);
    }
}
