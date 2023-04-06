using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speedMove = 10f;
    private float speedRotate = 75f;

    private float hInput;
    private float vInput;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        this.transform.Translate(Vector3.forward * vInput * speedMove * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput* speedRotate * Time.deltaTime);

    }
}
