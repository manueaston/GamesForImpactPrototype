using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMain : ButtonParent
{
    GameManager gameManager;
    bool active = false;

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
        spriteRenderer.color = Color.red;
    }

    IEnumerator Deactivate() // Coroutine
    {
        spriteRenderer.color = Color.white;

        // Button cooldown //
        yield return new WaitForSeconds(0.5f);
        // Waits for 0.5 seconds before deactivating so that button isn't instantly reactivated

        active = false;
        gameManager.ButtonDeactivated();
    }

    public bool IsActive()
    {
        return active;
    }
}
