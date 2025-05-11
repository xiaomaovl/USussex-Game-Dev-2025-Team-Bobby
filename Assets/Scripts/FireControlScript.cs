using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireControlScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject emptyCase;
    public GameObject fullCase;
    public GameObject bolt;
    public Transform ejectLocation;
    public Transform spawnPoint;
    public float bulletVelocity = 50;
    public ParticleSystem muzzleFlash;
    public bool oneInTheChamber = false;
    public bool hammerCocked = false;
    public AudioSource fireSound;
    public AudioSource hammerSound;
    public AudioSource triggerSound;
    
    public GameObject MagazineSocket;


    void Start()
    {
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(fire);
        //fireSound = GetComponent<AudioSource>();
    }

    public void fire(ActivateEventArgs args)
    {
        MagazineProperties magazine = MagazineSocket.GetComponent<XRSocketInteractorTag>().GetMagazineProperties();
        if (oneInTheChamber)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.transform.rotation = spawnPoint.rotation;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletVelocity;
            muzzleFlash.Play();
            fireSound.Play();
            fireSound.PlayOneShot(fireSound.clip);
            Destroy(spawnedBullet, 3);
            bolt.GetComponent<Rigidbody>().velocity = bolt.transform.forward * -10;
            ejectCase(true);

            if (magazine != null && magazine.ammo>0)
            {
                magazine.ammo--;
                magazine.updateBullets();
            }
            else { oneInTheChamber = false; }
        }
        else if (hammerCocked)
        {
            hammerSound.Play();
            hammerCocked = false;
        }
        else
        {
            //TODO play click sound
            triggerSound.Play();
        }
    }

    bool BoltState = true;

    public void RackBolt(bool BoltPos)
    {
        if(BoltPos == BoltState) { return; }
        BoltState = !BoltState;
        if (BoltState)
        {
            MagazineProperties magazine = MagazineSocket.GetComponent<XRSocketInteractorTag>().GetMagazineProperties();
            if (magazine != null && magazine.ammo > 0)
            {
                magazine.ammo--;
                magazine.updateBullets();
                if (oneInTheChamber)
                {
                    ejectCase(false);
                }
                oneInTheChamber = true;
            }
        }
        else
        {
            if (oneInTheChamber)
            {
                ejectCase(false);
            }
            oneInTheChamber = false;
            hammerCocked = true;
        }
    }

    public void ejectCase(bool isSpent)
    {
        float caseVel = 4f;
        if (isSpent)
        {
            GameObject spawnedCase = Instantiate(emptyCase);
            spawnedCase.transform.position = ejectLocation.position;
            spawnedCase.transform.rotation = ejectLocation.rotation;
            spawnedCase.GetComponent<Rigidbody>().velocity = (ejectLocation.right * caseVel) + (ejectLocation.up * caseVel);
            spawnedCase.GetComponent<Rigidbody>().angularVelocity = (ejectLocation.right * -100 );
            Destroy(spawnedCase, 20);
        }
        else
        {
            GameObject spawnedCase = Instantiate(fullCase);
            spawnedCase.transform.position = ejectLocation.position;
            spawnedCase.transform.rotation = ejectLocation.rotation;
            spawnedCase.GetComponent<Rigidbody>().velocity = (ejectLocation.right * caseVel * 0.5f) + (ejectLocation.up * caseVel * 0.5f);
            spawnedCase.GetComponent<Rigidbody>().angularVelocity = (ejectLocation.right * -100);
            Destroy(spawnedCase, 20);
        }
        
    
    }
}
