using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineProperties : MonoBehaviour
{

    public int ammo = 30;
    public GameObject bullets;
    // Start is called before the first frame update

    public void updateBullets()
    {
        if(ammo <= 0)
        {
            bullets.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
