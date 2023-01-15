using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    public TMP_Text bulletNumbers;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
}
