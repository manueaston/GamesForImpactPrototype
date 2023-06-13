using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinimiseWindow : ButtonParent
{
    GameObject window;  // Add window to toggle in instance - should be public
    bool windowActive;

    private void Awake()
    {
        // temporarily set the window here - need to find workaround
        window = GameObject.Find("ChatWindow");

        // windowActive = false; // minimise window at start
        // window.SetActive(windowActive);
    }

    public override void ButtonPressed()
    {
        windowActive = !windowActive; // toggle window 
        window.SetActive(windowActive);
    }
}
