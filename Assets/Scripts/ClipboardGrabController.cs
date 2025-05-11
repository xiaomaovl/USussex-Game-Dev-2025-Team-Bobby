using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClipboardController1 : MonoBehaviour
{
    public TypeWriterController controller;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(controller.activate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
