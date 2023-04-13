using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private GameBehaviour gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected");
            gameManager.Items += 1;
        }
    }
}
