using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 2f, -3f); //new Vector3(0f, 1.2f, -2.6f);
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(offset);
        this.transform.LookAt(target);
        
    }
}
