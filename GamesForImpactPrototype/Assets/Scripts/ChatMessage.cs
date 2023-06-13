using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MsgType
{
    Incoming,
    Outgoing
}

public class ChatMessage : MonoBehaviour
{
    public string msg;

    // Start is called before the first frame update
    void Start()
    {
        // should display message with text in the future
        // SpriteRenderer child = GetComponentInChildren<SpriteRenderer>();
        // switch (type)
        // {
        // case MsgType.Incoming:
        //     child.color = Color.red;
        //     break;
        // case MsgType.Outgoing:
        //     child.color = Color.blue;
        //     break;
        // default:
        //     break;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
