using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNotifWindow : Window
{
    // Start is called before the first frame update
    void Start()
    {
        // Should update a text element here, make a list of possible chat receipients/messages
        
        // before then, just check if chat window is open already
        if (GameObject.Find("ChatWindow").transform.localScale != new Vector3(0.0f, 0.0f, 0.0f))
        {
            Debug.Log("Chat window open - cancelling notification");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
