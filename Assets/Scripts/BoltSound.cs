using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSound : MonoBehaviour
{
    public AudioSource BoltForward;
    public AudioSource BoltBack;
    public GameObject Gun;
    private FireControlScript GunScript;

    private void Start()
    {
        GunScript = Gun.GetComponent<FireControlScript>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("BoltForward"))
        {
            GunScript.RackBolt(true);
            BoltForward.Play();
            BoltForward.PlayOneShot(BoltForward.clip);
        }
        else if (collider.gameObject.CompareTag("BoltRear"))
        {
            GunScript.RackBolt(false);
            BoltBack.Play();
            BoltBack.PlayOneShot(BoltBack.clip);
        }
    }
}
