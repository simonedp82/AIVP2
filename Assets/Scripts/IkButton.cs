using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkButton : MonoBehaviour
{
    public float myTime;
    public AnimationCurve ikWeight;
    public Transform ikTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //myTime += Time.deltaTime;
        //if(myTime >= 5)
        //{
        //    myTime = 0;
        //}
        if (AnimatedCharacter.Instance.rightHandObj != ikTarget) return;
        AnimatedCharacter.Instance.rightHandIkValue = ikWeight.Evaluate(myTime);
    }
}
