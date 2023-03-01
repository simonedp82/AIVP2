using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseController : MonoBehaviour
{
    public KeyCode keyUsed;
    public Animator _anim;

    [Range(0,1)]
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        _anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyUsed))
        {
            value += Time.deltaTime;
        }
        else
        {
            value -= Time.deltaTime;
        }

        value = Mathf.Clamp01(value);
        _anim.SetFloat("OpenPercentage", value);
    }
}
