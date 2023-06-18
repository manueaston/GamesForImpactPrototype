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
    protected SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
}