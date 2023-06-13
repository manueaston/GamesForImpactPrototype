using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSendMessage : ButtonParent
{
    public ChatWindow chat;
    public override void ButtonPressed()
    {
        // send a message to chat window
        // could pick from a random list of messages?
        // or instead call a chatbox, which has text input?
        chat.AddOutgoingMessage("msg sent");
    }
}
