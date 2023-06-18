using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWindow : Window
{
    public GameObject outgoingMsg;
    public GameObject incomingMsg;
    public GameObject msgObj; // empty object which holds messages

    // array to hold all possible incoming response sprites
    private static int msgCount = 23;
    public Sprite[] msgs = new Sprite[msgCount];
    // index of next message to send
    private int currentMsg = 0;

    void Start()
    {
        // hide the window
        transform.localScale = new Vector3(0, 0, 0);

        // send 1 incoming message
        StartCoroutine("ScheduleIncomingMessage");
    }

    void ShuffleMessages()
    {
        // move all messages up
        for (int i = 1; i <= msgObj.transform.childCount; i++)
        {
            // shuffle every child up 0.3f
            Transform child = msgObj.transform.GetChild(msgObj.transform.childCount - i);
            child.Translate(new Vector2(0.0f, 0.9f));
            // only show the first 5 messages
            if (i > 5)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void AddIncomingMessage(Sprite msg)
    {
        // add new message as child to messages gameObject
        GameObject newMsg = Instantiate(incomingMsg, new Vector2(msgObj.transform.position.x - 2.2f, msgObj.transform.position.y - 1.5f), Quaternion.identity, msgObj.transform);
        // SpriteRenderer spriteRenderer = newMsg.GetComponent<SpriteRenderer>();
        // SpriteRenderer spriteRenderer = newMsg.spriteRenderer;
        SpriteRenderer spriteRenderer = newMsg.transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = msg;

        ShuffleMessages();
    }

    IEnumerator ScheduleIncomingMessage()
    {
        // receive new message, with next msg sprite
        yield return new WaitForSeconds(1.0f);
        AddIncomingMessage(msgs[currentMsg % msgCount]);
        currentMsg++;
    }

    public void AddOutgoingMessage(Sprite msg)
    {
        // add new message as child to messages gameObject
        GameObject newMsg = Instantiate(outgoingMsg, new Vector2(msgObj.transform.position.x + 4.25f, msgObj.transform.position.y - 1.9f), Quaternion.identity, msgObj.transform);
        // SpriteRenderer spriteRenderer = newMsg.GetComponent<SpriteRenderer>();
        // SpriteRenderer spriteRenderer = newMsg.spriteRenderer;
        SpriteRenderer spriteRenderer = newMsg.transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = msg;
        ShuffleMessages();
        // respond with incoming message
        StartCoroutine("ScheduleIncomingMessage");
    }
}
