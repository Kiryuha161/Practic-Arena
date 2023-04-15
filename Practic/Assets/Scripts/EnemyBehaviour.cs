using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;

    private NavMeshAgent enemy;
    [SerializeField]private int localIndex = 0;

    private void Start()
    {
        patrolRoute = GameObject.Find("Patrol Route").GetComponent<Transform>();
        enemy = GetComponent<NavMeshAgent>();
        InitializedPatrolRoute();
        MoveToNextPosition();
    }

    private void Update()
    {
        if (enemy.remainingDistance < 0.2f && !enemy.pathPending)
        {
            MoveToNextPosition();
        }
    }

    private void MoveToNextPosition()
    {
        if (locations.Count == 0)
        {
            return;
        }

        enemy.destination = locations[localIndex].position;
        localIndex = (localIndex + 1) % locations.Count;
    }

    private void InitializedPatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player is found - attack!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
