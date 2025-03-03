using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseController : MonoBehaviour
{
    // Start is called before the first frame update
    HingeJoint hinge;
    private int timer = 0;
    bool activated = false;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= 200 && activated == false)
        {
            activated = true;
            hinge.useSpring = true;
        }
    }
}
