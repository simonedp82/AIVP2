using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletLogic : MonoBehaviour
{
    public BulletsStyle bulletInfo;

    public LayerMask mask;

    //Provvisoria
    public float bulletHitDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
      Destroy(this.gameObject, bulletInfo.bulletLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, bulletHitDistance, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            GameObject newHole = Instantiate(bulletInfo.bulletHole, hit.point,Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * bulletHitDistance, Color.green);
            Debug.Log("Did not Hit");
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Hittable"))
    //    {

    //      //GameObject newHole = Instantiate(bulletInfo.bulletHole, collision.contacts[0].point, collision.gameObject.transform.rotation);
    //    }

    //    Destroy(this.gameObject);

    //    //Debug.Log("Ho colpito  " + collision.gameObject.name);
    //}
}
