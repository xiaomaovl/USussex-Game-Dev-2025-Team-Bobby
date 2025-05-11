using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TypeWriterMessage
{
    // controls how fast text appears
    float timer = 0;
    int charIndex = 0;
    float timePerChar = 0.05f;
    public bool sentenceFinished = false;

    // fields for current message, display message and action callback
    // callback is for action to be performed after message finished showing
    [SerializeField] 
    public string currentMsg = null;
    string displayMsg = null;
    Action onActionCallback = null;

    // constructor
    public TypeWriterMessage(string msg, Action callback = null)
    {
        onActionCallback = callback;
        currentMsg = msg;
    }

    // function to return callback
    public void Callback()
    {
        if (onActionCallback != null) onActionCallback();
    }

    // returns currentMsg
    public string GetFullMsgAndCallback()
    {
        if (onActionCallback != null) onActionCallback();
        return currentMsg;
    }

    public string GetFullMsg()
    {
        return currentMsg;
    }

    public string GetMsg()
    {
        return displayMsg;
    }

    public void Update()
    {
        if (string.IsNullOrEmpty(currentMsg)) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // reveals one character every timePerChar
            timer += timePerChar;
            charIndex++;
            // assign message to typewriter functionality
            displayMsg = currentMsg.Substring(0, charIndex);
            displayMsg += "<color=#00000000>" + currentMsg.Substring(charIndex) + "</color>";
            // stop typing if end of sentence
            if (charIndex >= currentMsg.Length)
            {
                Callback();
                currentMsg = null;
                sentenceFinished = true;
            }
        }
    }

    public bool IsActive()
    {
        if (string.IsNullOrEmpty(currentMsg)) return false;
        return charIndex >= currentMsg.Length;
    }
}
public class TypeWriter : MonoBehaviour
{
    public TextMeshPro textComponent;
    static TypeWriter _instance;
    List<TypeWriterMessage> _messages = new List<TypeWriterMessage>();
    TypeWriterMessage _currentMsg = null;
    int _index = 0;
    int _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // add messages from any other script
    public static void Add(string msg, Action callback = null) 
    {
        TypeWriterMessage newMessage = new TypeWriterMessage(msg, callback);
        _instance._messages.Add(newMessage);
    }

    // static activate function
    public static void Activate()
    {
        _instance._currentMsg = _instance._messages[0];
    }

    // assign static reference of class
    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_messages.Count > 0 && _currentMsg != null)
        {
            _currentMsg.Update();
            // reassign currentMsg to TextComponent so message is "typed out" in real time
            textComponent.text = _currentMsg.GetMsg();
        }

        if (_currentMsg != null && _currentMsg.sentenceFinished)
        {
            _timer++;
            if (_timer >= 600)
            {
                WriteNextMessageInQueue();
                _timer = 0;
            }
        }
    }

    public void WriteNextMessageInQueue()
    {
        // if active show entire string
        if (_currentMsg != null && _currentMsg.IsActive())
        {
            // increment to next message
            // if no more messages exist or end of messages reached, return nothing so typewriter stops
            textComponent.text = _currentMsg.GetFullMsgAndCallback();
            _currentMsg = null;
            return;
        }
        _index++;
        // otherwise assign currentMsg to next message in list
        if (_index >= _messages.Count)
        {
            _currentMsg = null;
            textComponent.text = "";
            return;
        }
        _currentMsg = _messages[_index];
    }
}
