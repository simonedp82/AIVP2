using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public KeyCode first, secondary, third;
    public List<Transform> spellSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(first))
        {
            tryToThrowSpell(0);
        }

        if (Input.GetKeyDown(secondary))
        {
            tryToThrowSpell(1);
        }

        if (Input.GetKeyDown(third))
        {
            tryToThrowSpell(2);
        }
    }

    public void tryToThrowSpell(int index)
    {
        if(spellSlot[index].childCount != 0)
        {
            spellSlot[index].GetChild(0).GetComponent<UiInteraction>().throwSpell();
        }
        
    }
}
