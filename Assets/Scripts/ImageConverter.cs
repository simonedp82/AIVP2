using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ImageConverter : MonoBehaviour
{
    public RawImage _rawImage;
    public string base64String;
    public string mioNome;
    // Start is called before the first frame update
    void Start()
    {
        convertImage(base64String);
        if (!PlayerPrefs.HasKey("Nome"))
        {
            PlayerPrefs.SetString("Nome", mioNome);
        }
        else
        {
            mioNome = PlayerPrefs.GetString("Nome");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void convertImage(string imageString)
    {
        string b64_string = imageString;

        byte[] b64_bytes = System.Convert.FromBase64String(b64_string);

        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(b64_bytes);
        _rawImage.texture = tex;
        
    }
}
