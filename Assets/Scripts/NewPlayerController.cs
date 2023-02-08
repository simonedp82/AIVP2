using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float automaticSpeed;
    public float speed;
    public float rotationSpeed;
    public CharacterController _cc;

    public bool characterIsGrounded;

    public Vector3 jump;
    public float jumpHeight;
    public float gravity = -9.18f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterIsGrounded = _cc.isGrounded;

        if(characterIsGrounded && jump.y < 0)
        {
            jump.y = 0;
        }

        //float rotation = Input.GetAxis("Mouse X");
        //Vector3 rotationVector = new Vector3(0, rotation, 0)* rotationSpeed * Time.deltaTime;
        //transform.Rotate(rotationVector);

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        Vector3 move = new Vector3(x, 0, automaticSpeed);        
        
        Vector3 directionalMoviment = transform.TransformDirection(move);
        _cc.Move(directionalMoviment * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && characterIsGrounded)
        {
            jump.y += jumpHeight * gravity * -1;
        }

        jump.y += gravity * Time.deltaTime;
        _cc.Move(jump * Time.deltaTime);
    }
}
