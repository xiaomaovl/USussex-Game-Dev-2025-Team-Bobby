using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CaseController : MonoBehaviour
{
    // Start is called before the first frame update
    HingeJoint hinge;
    private int timer = 0;
    bool activated = false;

    public GameObject parent;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        XRGrabInteractable grab = parent.GetComponent<XRGrabInteractable>();
        //grab.activated.AddListener(open);
        grab.hoverEntered.AddListener(open);
    }

    public void open(HoverEnterEventArgs args) 
    {
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        //timer++;
        //if (timer >= 200 && activated == false)
        //{
        //    activated = true;
        //    hinge.useSpring = true;
        //}
    }
}
