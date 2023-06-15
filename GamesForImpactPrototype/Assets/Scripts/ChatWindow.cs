using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWindow : Window
{
    public GameObject outgoingMsg;
    public GameObject incomingMsg;
    public GameObject msgObj; // empty object which holds messages

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleMessages()
    {
        // move all messages up
        for (int i = 1; i <= msgObj.transform.childCount; i++)
        {
            // shuffle every child up 0.3f
            Transform child = msgObj.transform.GetChild(msgObj.transform.childCount - i);
            child.Translate(new Vector2(0.0f, 0.3f));
            // only show the first 5 messages
            if (i > 8)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void AddIncomingMessage(string msg)
    {
        // add new message as child to messages gameObject
        GameObject newMsg = Instantiate(incomingMsg, new Vector2(msgObj.transform.position.x - 0.5f, msgObj.transform.position.y - 1.5f), Quaternion.identity, msgObj.transform);
        ShuffleMessages();
    }

    IEnumerator ScheduleIncomingMessage(string msg)
    {
        yield return new WaitForSeconds(1.0f);
        AddIncomingMessage("response");
    }

    public void AddOutgoingMessage(string msg)
    {
        // add new message as child to messages gameObject
        GameObject newMsg = Instantiate(outgoingMsg, new Vector2(msgObj.transform.position.x + 1.5f, msgObj.transform.position.y - 2.5f), Quaternion.identity, msgObj.transform);
        ShuffleMessages();
        // respond with incoming message
        StartCoroutine("ScheduleIncomingMessage", "response");
    }
}
