using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLevel : MonoBehaviour
{
    [Header("Procedural")]
    public AnimationCurve curveA;
    public AnimationCurve curveB;
    public GameObject tesselObject;

    [Range(0.01f,1)]
    public float tesselDimension;
    public Vector2 sceneSize;


    [Header("Endless")]    
    public List<GameObject> sections;
    public float sectionLenght;
    public int maxSections;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnEndless();

        //generateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateObjects()
    {
        for(int i=0; i< sceneSize.x; i++)
        {
            for (int y = 0; y < sceneSize.y; y++)
            {
                GameObject go = Instantiate(tesselObject);

                float yAtDistanceByA = curveA.Evaluate(i);
                float yAtDistanceByB = curveB.Evaluate(y);

                float interpolaterValue = (yAtDistanceByA + yAtDistanceByB);
                go.transform.position = new Vector3(y, interpolaterValue, tesselDimension * i);
            }
                
        }
    }

    public void spawnEndless()
    {
        for (int i = 0; i < maxSections; i++)
        {
            int sectionIndex = Random.Range(0, sections.Count);
            GameObject go = Instantiate(sections[sectionIndex]);
            go.transform.position = new Vector3(0, 0, sectionLenght * i);
        }
    }
}
