using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    void Awake(){

        weapon = weaponHolder;

    }

    void Start()
    {
        if (weapon != null){
            TurnVisual(false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Weapon pickedWeapon = other.gameObject.GetComponentInChildren<Weapon>();
            if(pickedWeapon != null){
                pickedWeapon.transform.SetParent(pickedWeapon.parentTransform);
                pickedWeapon.transform.localPosition = new Vector3(0, 0, 0);
                Debug.Log("Weapon picked up");
                TurnVisual(false, pickedWeapon);
            }

            weapon.transform.parent = other.transform;
            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = new Vector3(0,0,0);

            gameObject.SetActive(false);
            TurnVisual(true, weapon);
        }

    }


    public void TurnVisual(bool on)
    {
        if(weapon != null){
            weapon.gameObject.SetActive(on);
        }
    }

    public void TurnVisual(bool on, Weapon weapon)
    {
        if(weapon != null){
            weapon.gameObject.SetActive(on);
        }
    }
}

