using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClipboardController : MonoBehaviour
{
    public GameObject textBox;
    private int _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (textBox == null)
        {
            Debug.Log("Null text");
        }
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _timer++;
        if (_timer == 200)
        {
            textBox.SetActive(true);
        }
    }
}
