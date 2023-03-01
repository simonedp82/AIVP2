using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : Singleton<InventoryManager>
{
    public Transform slotSelected;
    public Transform lastImageOverlapped;
    public Transform generalParent;

    public List<Transform> bagContainers;
    public List<Transform> handContainers;

    public List<GameObject> itemExample;
    public GameObject testGetItem;

    public GameObject notifyPanel;
    public TMP_Text notifyMessage;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        //Popolo randomicamente l'inventario
        for(int i = 0; i < 2; i++)
        {
            int itemIndex = Random.Range(0, itemExample.Count);
            GameObject go = Instantiate(itemExample[itemIndex], bagContainers[i].transform);
            go.transform.localPosition = Vector3.zero;
            go.GetComponent<UiInteraction>().lastSlot = bagContainers[i];


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            getItemDebug();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }

    public void getItemDebug()
    {
        int itemIndex = Random.Range(0, itemExample.Count);
        bool isFull = true;
        foreach(Transform t in bagContainers)
        {
            if(t.childCount == 0)
            {
                GameObject go = Instantiate(itemExample[itemIndex], t);
                go.transform.localPosition = Vector3.zero;
                go.GetComponent<UiInteraction>().lastSlot = t;
                isFull = false;
                break;
            }
        }
        if (isFull)
        {
            setNotify("Inventory Full");
        }
    }

    public void setNotify(string message)
    {
        notifyMessage.text = message;
        notifyPanel.SetActive(true);
    }
}
