using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    public float damage = 18;
    public float fireSpeed = 1;
    public float impactForce = 50f;
    public Camera cam;
    public float range = 50;
    public AudioClip shot;
    public AudioSource audioShot;
    public ParticleSystem effect;
    public GameObject impactEffect;
    public int bullCount; // количество патрон в обойме
    public int bullMax; // всего патрон
    public int bullMiss; // сколько патрон нужно перезарядить
    // Start is called before the first frame update
    private float nextTimeToFire = 0f;
    void Start()
    {
        bullCount = 10;
        bullMax = 30;
        bullMiss = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/ fireSpeed;
            shootGun();
        }
        if(Input.GetKeyDown(KeyCode.R) && bullCount < 10 && bullMax > 0){
            Reload();
        }
    }

    public void shootGun(){
        if(bullCount > 0)
        {
            bullCount--;
            bullMiss++;
            effect.Play();
            audioShot.PlayOneShot(shot);
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if(enemy != null){
                    enemy.TakeDamage(damage);
                }
                if(hit.rigidbody != null){
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }
    public void Reload(){
        if((bullMax + bullCount) < 10){
            bullCount = bullCount + bullMax;
            bullMax = 0;
            bullMiss = 10 - bullCount;
        } else {
            bullMax = bullMax - bullMiss;
            bullCount = 10;
            bullMiss = 0;
        }
    }
}