using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        InventoryManager.Instance.slotSelected = this.gameObject.transform;
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        InventoryManager.Instance.slotSelected = null;
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
