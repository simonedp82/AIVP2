using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlelr : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(x, 0, z));
    }
}
