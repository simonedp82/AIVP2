using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsSpawner : MonoBehaviour
{
    public List<Transform> spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in spawnPoint)
        {
            int isSpawn = Random.Range(0, 2);

            if(isSpawn == 0)
            {
                GameObject go = Instantiate(ProceduralLevel.Instance.props[Random.Range(0, ProceduralLevel.Instance.props.Count)], t.position, t.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
