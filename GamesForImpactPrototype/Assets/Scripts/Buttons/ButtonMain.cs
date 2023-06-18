using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMain : ButtonParent
{
    GameManager gameManager;
    bool active = false;

    // sprites
    public Sprite off, on, pressed;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start(); // Calls parent button start function
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void ButtonPressed()
    {
        if (active)
        {
            StartCoroutine(Deactivate());
        }
    }

    // Game Manager calls activate to tell player to press button
    public void Activate()
    {
        active = true;
        spriteRenderer.sprite = on;
    }

    IEnumerator Deactivate() // Coroutine
    {
        spriteRenderer.sprite = pressed;

        // Button cooldown //
        yield return new WaitForSeconds(0.5f);
        // Waits for 0.5 seconds before deactivating so that button isn't instantly reactivated

        spriteRenderer.sprite = off;
        active = false;
        gameManager.ButtonDeactivated();
    }

    public bool IsActive()
    {
        return active;
    }
}
