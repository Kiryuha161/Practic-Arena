using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"));
        {
            Debug.Log("Player is found - attack!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"));
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
