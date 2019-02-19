using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private WeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    private float damage = 20f;

    void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        WeaponShot();
	}

    void WeaponShot()
    {
        if (weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MUTIPLE)
        {
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();

                //BulletFired();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(weaponManager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                if(weaponManager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                    //BulletFired();
                }
                else
                {
                     
                }
            }
        }
    }
}
