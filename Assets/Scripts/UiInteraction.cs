using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Animator _anim;
    public Vector3 startPosition;
    public Transform lastSlot;
    public spellType spell;
    public float coolDown;
    private Image _image;

    public void OnDrag(PointerEventData eventData)
    { if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        transform.position = eventData.position;
        //throw new System.NotImplementedException();
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        transform.parent = InventoryManager.Instance.generalParent;
        transform.SetAsLastSibling();
        startPosition = transform.position;
        GetComponent<Image>().raycastTarget = false;
        //throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        _anim.SetBool("IsHover", true);
        InventoryManager.Instance.lastImageOverlapped = this.transform;
        
       // throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        _anim.SetBool("IsHover", false);
        InventoryManager.Instance.lastImageOverlapped = null;
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!InventoryManager.Instance.inventory.activeInHierarchy) return;
        GetComponent<Image>().raycastTarget = true;

        if(InventoryManager.Instance.slotSelected != null && InventoryManager.Instance.slotSelected.childCount==0)
        {
            lastSlot = InventoryManager.Instance.slotSelected;
            transform.parent = InventoryManager.Instance.slotSelected;
            transform.localPosition = Vector3.zero;

        }
        else if(InventoryManager.Instance.lastImageOverlapped != null)
        {
            Transform myTransform = lastSlot;
            Transform destination = InventoryManager.Instance.lastImageOverlapped.parent;

            InventoryManager.Instance.lastImageOverlapped.SetParent(myTransform);
            InventoryManager.Instance.lastImageOverlapped.localPosition = Vector3.zero;
            InventoryManager.Instance.lastImageOverlapped.GetComponent<UiInteraction>().lastSlot = myTransform;

            transform.SetParent(destination);
            transform.localPosition = Vector3.zero;
            lastSlot = destination;
        }
        else
        {
            transform.parent = lastSlot;
            transform.localPosition = Vector3.zero;

        }
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_image.fillAmount < 1)
        {
            float nowFilling = _image.fillAmount;
            nowFilling += coolDown * Time.deltaTime;
            _image.fillAmount = Mathf.Clamp01(nowFilling);
        }

    }

    public void throwSpell()
    {
        if(_image.fillAmount == 1)
        {
            Debug.Log("Spell throwed");
            _image.fillAmount = 0;
        }
    }
}

public enum spellType { fuoco, aria, acqua, terra, fulmine}

