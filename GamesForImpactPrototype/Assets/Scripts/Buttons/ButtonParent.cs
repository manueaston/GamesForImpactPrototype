using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonParent : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown() // Called when button is clicked
    {
        ButtonPressed();
    }

    public abstract void ButtonPressed();
}
