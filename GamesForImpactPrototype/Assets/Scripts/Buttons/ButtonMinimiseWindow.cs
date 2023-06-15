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
        ToggleWindowVisibility(windowActive);
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
