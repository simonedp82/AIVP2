using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCharacter : MonoBehaviour
{
    public Animator _anim;
    public bool crouched;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        _anim.SetFloat("Forward", y);
        _anim.SetFloat("Side", x);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouched = !crouched;
            _anim.SetBool("IsCrouck", crouched);
        }
           
    }
}
