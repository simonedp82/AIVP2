using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UiManager : Singleton<UiManager>
{
    public TMP_Text bulletNumbers;

    public GameObject notifyPanel;
    public TMP_Text notifyText;

    public List<associativo> poteri;

    public GameObject selectedUiObject;

    public Dictionary<string, int> myDictionary = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        myDictionary.Add("Primo", 10);

    }

    public void getNewPower(string powerName, int powerAmount)
    {
        try
        {
            myDictionary.Add(powerName, powerAmount);
        }
        catch
        {
            int residualPower = myDictionary[powerName];
                myDictionary[powerName] = residualPower + powerAmount; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //updateBulletNumer(Shooting.Instance.avaibleBullet[Shooting.Instance.activeWeapon]);
    }

    public void updateBulletNumer(int bullets)
    {
        bulletNumbers.text = bullets.ToString();
    }

    public void spawNotify(string message)
    {
        notifyPanel.SetActive(true);
        notifyText.text = message;
        Time.timeScale = 0;
    }

    public void hideNotify()
    {
        notifyPanel.SetActive(false);
        Time.timeScale = 1;

    }
}

[System.Serializable]
public struct associativo
{
    public string potere;
    public int quantità;

}
