using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazineSound : MonoBehaviour
{
    public AudioSource Insert;
    public AudioSource Remove;

    void Start()
    {
         XRSocketInteractorTag Socket  = GetComponent<XRSocketInteractorTag>();
        Socket.selectEntered.AddListener(playInsert);
        Socket.selectExited.AddListener(playRemove);
    }
    void playInsert(SelectEnterEventArgs args)
    {
        Insert.Play();
    }

    void playRemove(SelectExitEventArgs args)
    {
        Remove.Play();
    }
}
