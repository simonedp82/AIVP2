using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestQuaternioni : MonoBehaviour
{
    public List<Transform> objects;
    public TMP_Text debugText;
    public Vector3 rot;

    public Transform a, b;
    float timeCount = 0.0f;
    float speed = 0.01f;
    public float bobAmpitude;
    public float bobSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Imposta la rotazione a NESSUNA ROTAZIONE
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    foreach(Transform t in objects)
        //    {
        //        t.localRotation = Quaternion.identity;
        //    }
        //}

        float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmpitude;
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        //transform.Rotate(new Vector3(x, y, 0));

        rot += new Vector3(x, y,0);
        rot.z = bob;
        //Imposta la rotazione partendo da un Vector3
        transform.rotation = Quaternion.Euler(rot);

        //Angle
        //float angle = Quaternion.Angle(a.rotation, b.rotation);
        //debugText.text = angle.ToString();

        //Agle Axis
        //a.transform.rotation = Quaternion.AngleAxis(30, Vector3.up);

        //From Rotation
        //a.transform.rotation = Quaternion.FromToRotation(a.transform.up, b.transform.forward);

        //inverse
        //a.rotation = Quaternion.Inverse(b.rotation);

        //Lerp
        //a.rotation = Quaternion.Lerp(a.rotation, b.rotation, timeCount * speed);
        //timeCount = timeCount + Time.deltaTime;
        //debugText.text = transform.eulerAngles.ToString();
    }
}
