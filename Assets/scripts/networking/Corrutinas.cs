using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutinas : MonoBehaviour {
    public static Corrutinas singletone;

    void Awake()
    {
        if (singletone != null)
        {
            Debug.LogError("More than one gameManager instanciated");
        }
        else
        {
            singletone = this;
        }
    }

    //corutina para el reloading de las armas
    //public void ReloadDelay(ItemScript WeaponItem)
    //{
    //    StartCoroutine(reloadingTime(WeaponItem));
    //}
    //IEnumerator reloadingTime(ItemScript WeaponItem)
    //{
    //    WeaponItem.animator.SetTrigger("Reload");
    //    WeaponItem.playSound(WeaponItem.reloadSound);
    //    WeaponItem.reloading = true;
    //    yield return new WaitForSeconds(WeaponItem.reloadTime);
    //    if (WeaponItem != null)
    //    {
    //        WeaponItem.reloading = false;
    //    }
    //}
}
