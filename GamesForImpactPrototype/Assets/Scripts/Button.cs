using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    GameManager gameManager;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown() // Called when button is clicked
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
