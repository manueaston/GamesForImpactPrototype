using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSendMessage : ButtonParent
{
    public ChatWindow chat;

    // emotes
    // private static int emoteCount = 6;
    // public Sprite emote1, emote2, emote3, emote4, emote5, emote6;
    // public Sprite[] emotes = new Sprite[emoteCount];
    public Sprite currentEmote;

    public override void ButtonPressed()
    {
        // send a message to chat window
        // picks a random emote sprite to send
        chat.AddOutgoingMessage(currentEmote);
        // currentEmote = emotes[Random.Range(0, emoteCount - 1)];
        // spriteRenderer.sprite = currentEmote;
    }
}
