using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float _speedMove = 10f;
    private float _speedRotate = 75f;
    private float _jumpForce = 5f;
    private float _distanceToGround = 0.1f;
    private float _bulletSpeed = 15f;

    private float _hInput;
    private float _vInput;

    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private GameObject bulletPrefab;
    private CapsuleCollider _col;
    private Rigidbody _rb;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col= GetComponent<CapsuleCollider>();
    }

    
    private void Update()
    {
        _hInput = Input.GetAxis("Horizontal") * _speedRotate;
        _vInput = Input.GetAxis("Vertical") * _speedMove;

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), transform.rotation) as GameObject;

            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = transform.forward * _bulletSpeed;
        }
        

    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.deltaTime);
        
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.deltaTime);
        _rb.MoveRotation(_rb.rotation * angleRotation);
        
    }

    private bool IsGrounded()
    {
        Vector3 colliderBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, colliderBottom, _distanceToGround, _layerGround, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}


        




