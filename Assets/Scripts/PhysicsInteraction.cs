using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsInteraction : MonoBehaviour
{
    public Rigidbody _rb;

    [Range(-10,10)]
    public float xForce;
    [Range(0, 10)]
    public float yForce;
    [Range(-10, 10)]
    public float zForce;

    public Transform com;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = com.localPosition;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //Debug.DrawLine(transform.position, new Vector3(transform.position.x + xForce, transform.position.y + yForce, transform.position.z +  zForce),Color.red);
        //_rb.AddForce(new Vector3(xForce, yForce, zForce), ForceMode.Force);
        //_rb.AddRelativeForce(new Vector3(xForce, yForce, zForce), ForceMode.Force);
        
    }
}
