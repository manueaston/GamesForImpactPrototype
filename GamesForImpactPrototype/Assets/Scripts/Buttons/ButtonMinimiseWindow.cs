using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinimiseWindow : ButtonParent
{
    public string windowTitle;
    GameObject window;  // Add window to toggle in instance - should be public
    bool windowActive;

    new void Start()
    {
        // set the window
        window = GameObject.Find(windowTitle);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void ButtonPressed()
    {
        windowActive = !windowActive; // toggle window 
        ToggleWindowVisibility(windowActive);
    }

    void ToggleWindowVisibility(bool Visible)
    {
        if (Visible)
        {
            window.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            window.transform.localScale = new Vector3(0, 0, 0); // Setting scale to (0, 0, 0) makes window invisible
        }
    }
}
