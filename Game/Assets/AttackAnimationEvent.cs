
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationEvent : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponColl;
    public void WApear()
    {
        weapon.SetActive(true);
        weaponColl.SetActive(true);
    }

    public void WDisapear()
    {
        weapon.SetActive(false);
        weaponColl.SetActive(false);
    }
}
