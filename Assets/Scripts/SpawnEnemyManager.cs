using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public float timer;
    public List<Transform> spawnPoint;
    public GameObject enemyModel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer<= 0)
        {
            timer = Random.Range(3, 6);
            spawnNext();
        }
    }

    public void spawnNext()
    {
        
        int spawner = Random.Range(0, spawnPoint.Count);
        Instantiate(enemyModel, spawnPoint[spawner].position, Quaternion.identity);
    }
}
