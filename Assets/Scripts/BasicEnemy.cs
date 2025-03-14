using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject player;
    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindWithTag("Player");
    }
   
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Damage")
        {
            TakeDamage(5);
            Debug.Log("Enemy has been attacked.");
        }
    }

     

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Debug.Log("Enemy has died.");
            Die();
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
