using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseWindow : ButtonParent
{
    public override void ButtonPressed()
    {
        Destroy(transform.parent.gameObject); // Destroys parent window gameObject that button is attached to
    }
}
