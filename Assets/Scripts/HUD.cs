using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    weapon_switch weaponSwitch;
    gunManager g;
    gunManager1 g1;
    Player hp;
    public GameObject obj;
    public GameObject ammo;
    public GameObject ammo1;
    public GameObject HP;
    private int weapon;
    public Text Ammo;
    public Text Health;
    // Start is called before the first frame update
    void Start()
    {
        weaponSwitch = obj.GetComponent<weapon_switch>();
        g = ammo.GetComponent<gunManager>();
        g1 = ammo1.GetComponent<gunManager1>();
        hp = HP.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = weaponSwitch.weaponSwitch;
        if(weapon == 0){
            Ammo.text = g.bullCount.ToString() + "/" + g.bullMax.ToString();
        }
        if(weapon == 1){
            Ammo.text = g1.bullCount.ToString() + "/" + g1.bullMax.ToString();
        }
        Health.text = hp.health.ToString();
    }
}
