using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    public GameObject GlobalVolume;
    Volume volume;
    Vignette vignette;
    float intensity;



    public float health;
    public float maxHealth;
    public float maxIntensity = 0.6f;

    void Start()
    {
        volume = GlobalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(health);
            //health -= 5;
            StartCoroutine(TakeDamage(5));
            float normalizedHealth = Mathf.Clamp01(health / 100f);
            intensity = Mathf.Lerp(maxIntensity, 0f, normalizedHealth);
            vignette.intensity.value = intensity;
        }

    }

    IEnumerator TakeDamage(float dmg)
    {
        float normalizedHealth = Mathf.Clamp01(health / 100f);
        intensity = Mathf.Lerp(maxIntensity, 0f, normalizedHealth);
        vignette.intensity.value = intensity;
        health -=dmg;
        float tempintensity = intensity + 0.2f;
        vignette.intensity.value = intensity;

        yield return new WaitForSeconds(0.2f);

        while (tempintensity > intensity)
        {
            tempintensity -= 0.01f;
            if (tempintensity < intensity) tempintensity = intensity;
            vignette.intensity.value = tempintensity;
            yield return new WaitForSeconds(0.03f);
        }

        //vignette.enabled.Override(false);

        yield break;
    }

    /*
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(5);
        }
    }
    */

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("fart");
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            StartCoroutine(TakeDamage(5));
        }
    }
}
