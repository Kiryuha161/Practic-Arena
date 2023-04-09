using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float _speedMove = 10f;
    private float _speedRotate = 75f;

    private float _hInput;
    private float _vInput;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        _hInput = Input.GetAxis("Horizontal") * _speedRotate;
        _vInput = Input.GetAxis("Vertical") * _speedMove;

        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.deltaTime);

        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.deltaTime);
        _rb.MoveRotation(_rb.rotation * angleRotation);
        //_rb.AddForce(new Vector3(0, 0, _vInput), ForceMode.Force);
        //_rb.AddTorque(new Vector3(0, _hInput, 0), ForceMode.Force);

        
    }
        
        
}
