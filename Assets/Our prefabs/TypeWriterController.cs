using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TypeWriterController : MonoBehaviour
{
    public string[] messages = new string[0];
    // Start is called before the first frame update
    private void Start()
    {
        // initialise string array as described in object inspector
        foreach (string s in messages)
        {
            TypeWriter.Add(s);
        }
        // activate typewriter
        TypeWriter.Activate();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
