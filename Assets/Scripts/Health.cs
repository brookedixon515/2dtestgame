using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public Slider slider;
    public GameObject DeathMenu;

    public bool freezing = false;

    float lastFreezeDamageTime;   //The last time freeze damage was applied.
    float freezeDamageFrequency = 3f;  //How often freeze damage should be applied.

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth; 
        slider.value = currentHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;

        if(currentHealth <= 0)
        {
            Debug.Log("Player has died.");
            Die();
        }
        
    }

    void Die()
    {
        DeathMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(freezeBar.freezing == true && Time.time >= lastFreezeDamageTime + freezeDamageFrequency)
        {
            lastFreezeDamageTime = Time.time;
            currentHealth--;
            slider.value = currentHealth;

                if(currentHealth <= 0)
        {
            Debug.Log("Player has died.");
            Die();
        }
        }
    }
}
