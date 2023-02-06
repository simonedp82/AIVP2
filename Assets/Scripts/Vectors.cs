using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vectors : MonoBehaviour
{
    public TMP_Text debugText;
    private void Update()
    {
        debugText.text = transform.rotation.ToString();
    }
}
