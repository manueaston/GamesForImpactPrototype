using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinimiseWindow : ButtonParent
{
    public GameObject window;  // Add window to toggle in instance
    bool windowActive;

    private void Awake()
    {
        windowActive = false; // minimise window at start
        window.SetActive(windowActive);
    }

    public override void ButtonPressed()
    {
        windowActive = !windowActive; // toggle window 
        window.SetActive(windowActive);
    }
}
