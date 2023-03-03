using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCharacter : Singleton<AnimatedCharacter>
{
    public Animator _anim;
    public bool crouched;

    public bool ikActive;
    [Range(0, 1)]
    public float rightHandIkValue, leftFootValue,rightFootValue;

    public Transform rightHandObj, leftFootTarget, rightFootTarget;

    public bool onSkate;
    public Transform skate;
    public Vector3 offsetFromSkate;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onSkate) 
        {
            transform.position = skate.position + offsetFromSkate;
            transform.rotation = Quaternion.Lerp(transform.rotation, skate.rotation, rotationSpeed);
        }
        else
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

    private void OnAnimatorIK(int layerIndex)
    {
        if (ikActive)
        {
            if (rightHandObj != null)
            {
                _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandIkValue);
                _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandIkValue);
                _anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                _anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
            }
            else
            {
                _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            }
            if (leftFootTarget != null)
            {
                _anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootValue);
                _anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootValue);
                _anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTarget.position);
                _anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootTarget.rotation);
            }
            if (rightFootTarget != null)
            {
                _anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootValue);
                _anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootValue);
                _anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTarget.position);
                _anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootTarget.rotation);
            }
        }
        
    }
}
