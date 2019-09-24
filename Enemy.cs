using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public int pointValue = 1;
    public float speed;
    public float sightRadius = 10f;
    public GameObject deathEffect;

    private Transform target;
    private Vector3 force;

	NavMeshAgent nm;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		nm = GetComponent<NavMeshAgent>();
        speed = Random.Range(4.0f, 8f);
    }
    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= sightRadius)
        {
            nm.SetDestination(target.position);
        } 
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
}
