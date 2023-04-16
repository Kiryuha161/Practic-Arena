using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform PatrolRoute;
    public List<Transform> Locations;


    private Transform _player;
    private NavMeshAgent enemy;
    
    [SerializeField]private int localIndex = 0;
    private int _hp = 3;
    public int EnemyHP 
    { 
        get 
        {
            return _hp;
        }
        set
        {
            _hp= value;
            if (_hp <= 0)
            {
                Destroy(gameObject);
                Debug.LogFormat("Enemy down!");
            }
        }
    }



    private void Start()
    {
        PatrolRoute = GameObject.Find("Patrol Route").GetComponent<Transform>();
        _player = GameObject.Find("Player").transform;
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
        if (Locations.Count == 0)
        {
            return;
        }

        enemy.destination = Locations[localIndex].position;
        localIndex = (localIndex + 1) % Locations.Count;
    }

    private void InitializedPatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            enemy.destination = _player.position;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyHP -= 1;
            Debug.LogFormat($"Enemy get damage. Lost {EnemyHP}");
        }
    }
}
