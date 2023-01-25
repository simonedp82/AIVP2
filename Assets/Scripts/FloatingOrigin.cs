using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingOrigin : MonoBehaviour
{
    public Transform cameraTransform;
    public float zCameraPosition;
    public Transform player;

    public float maxZ = 100;

    public List<Transform> objectsToMove;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        zCameraPosition = cameraTransform.position.z;
        if(zCameraPosition >= maxZ)
        {
            resetPosition();
        }
    }

    public void resetPosition()
    {
        Vector3 playerOffset = player.position;

        foreach(Transform t in objectsToMove)
        {
            t.position = t.position - playerOffset;
        }
    }
}
