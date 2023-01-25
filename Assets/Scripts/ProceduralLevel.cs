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
    public Transform tileContainer;

    [Header("spawn Control")]
    public Transform cameraTransform;
    public float zCameraPosition;
    public float lastBlockzPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnEndless();
        cameraTransform = Camera.main.transform;

        //generateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        zCameraPosition = cameraTransform.position.z;
        lastBlockzPosition = tileContainer.GetChild(tileContainer.childCount -3).transform.position.z;
        if(zCameraPosition >= lastBlockzPosition)
        {
            instantiateNewTile(tileContainer.GetChild(tileContainer.childCount - 1).localPosition.z);

        }

        if(tileContainer.childCount > maxSections)
        {
            Destroy(tileContainer.GetChild(0).gameObject);
        }
    }

    public void instantiateNewTile(float zPosition)
    {
        int sectionIndex = Random.Range(0, sections.Count);
        GameObject go = Instantiate(sections[sectionIndex], tileContainer);
        go.transform.localPosition = new Vector3(0, 0, zPosition + sectionLenght);
        //Destroy(tileContainer.GetChild(0).gameObject);
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
            GameObject go = Instantiate(sections[sectionIndex], tileContainer);
            go.transform.localPosition = new Vector3(0, 0, sectionLenght * i);
        }
    }
}
