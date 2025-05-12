using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AIFireControlScript : MonoBehaviour
{
    public GameObject bullet;

    public Transform spawnPoint;
    public float bulletVelocity = 50;
    public ParticleSystem muzzleFlash;

    public AudioSource fireSound;

    



    void Start()
    {

        //fireSound = GetComponent<AudioSource>();
    }

    public void fire()
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.transform.rotation = spawnPoint.rotation;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletVelocity;
        muzzleFlash.Play();
        fireSound.Play();
        fireSound.PlayOneShot(fireSound.clip);
        Destroy(spawnedBullet, 3);

    }


}
