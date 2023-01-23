using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Singleton<Shooting>
{
    public GameObject bullet;
    public Transform muzzle;
    public float bulletForce;

    public int activeWeapon;
    public List<BulletsStyle> bulletsType;

    public List<int> avaibleBullet;
    // Start is called before the first frame update
    void Start()
    {
       
        foreach(BulletsStyle bs in bulletsType)
        {
            avaibleBullet.Add(bs.startBulletsNumber);
        }

       UiManager.Instance.updateBulletNumer(avaibleBullet[activeWeapon]);
    }

    
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            shootNow();

        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    GameObject newBullet = Resources.Load("Bullets/BulletResource") as GameObject;
        //    Instantiate(newBullet);
        //}
    }

    public void shootNow()
    {
        if (avaibleBullet[activeWeapon] == 0) return;
        avaibleBullet[activeWeapon]--;
        UiManager.Instance.updateBulletNumer(avaibleBullet[activeWeapon]);
        
        GameObject newBullet = Instantiate(bulletsType[activeWeapon].bulletModel, muzzle.position, muzzle.rotation);
        newBullet.GetComponent<BulletLogic>().bulletInfo = bulletsType[activeWeapon];
        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletsType[activeWeapon].bulletForce);
    }
}

[System.Serializable]
public struct bulletsInfo
{
    public GameObject bulletModel;
    public float bulletForce;
}
