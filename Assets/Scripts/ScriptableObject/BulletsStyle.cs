using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Customization/Bullets", order = 1)]
public class BulletsStyle : ScriptableObject
{
    public GameObject bulletModel;
    public float bulletForce;
    public float bulletDamage;
    public float bulletLife;
    public GameObject bulletHole;
    public int startBulletsNumber;
}
