using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Eventi : MonoBehaviour
{
    public List<quests> quest;
    public int questToStart;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entrato in collisione");
        
    }

    private void OnEnable()
    {
        Debug.Log("Enable");
        quest[questToStart].onQuestStart.Invoke();
    }

    private void OnDestroy()
    {
        
    }

    private void OnApplicationQuit()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Uscito dalla collisione");
    }

    private void OnTriggerEnter(Collider other)
    {
        //codice da eseguire quando entro in un trigger
        Debug.Log("Entrato");
    }

    private void OnTriggerExit(Collider other)
    {
        //codice da eseguire quando esco in un trigger
        Debug.Log("Uscito");
    }

    private void OnTriggerStay(Collider other)
    {
        //codice da eseguire quando sono all'interno di un trigger
    }
}

[System.Serializable]
public struct quests
{
    public string questName;
    public int nextQuestIfWin, nectQuestifFailed;
    public UnityEvent onQuestStart, onQuestWin, onQuestCompleted, onQuestFailed, onQuestEnd;
}
