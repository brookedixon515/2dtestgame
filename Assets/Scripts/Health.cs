using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    public bool freezing = false;

    float lastFreezeDamageTime;   //The last time freeze damage was applied.
    float freezeDamageFrequency = 3f;  //How often freeze damage should be applied.

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if(freezing == true && Time.time >= lastFreezeDamageTime + freezeDamageFrequency)
        {
            lastFreezeDamageTime = Time.time;
            currentHealth--;
        }
    }
}
