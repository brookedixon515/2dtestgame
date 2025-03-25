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
    public int damage;
    public GameObject drop;
    public GameObject enemy;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindWithTag("Player");
    }
   


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Damage")
        {
            doDamage(5);
            Debug.Log("Enemy has been attacked.");
        }

        if(other.gameObject.tag == "Player")
        {
        agent.SetDestination(player.transform.position);
        }

    }

    public void doDamage(int damage)
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
        drop.transform.parent = null;
        enemy.SetActive(false);
        drop.SetActive(true);
    }

    
}
