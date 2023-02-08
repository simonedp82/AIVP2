using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLogic : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * -1 * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisione con " + collision.gameObject.name);
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collisione con player");
            UiManager.Instance.avaibleLife--;
            UiManager.Instance.showLifes();
            Destroy(this.gameObject);
        }
    }
}
