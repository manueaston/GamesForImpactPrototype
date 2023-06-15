using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for making objects be able to scroll on mouse drag.
// Only scrolls in y direction
public class Scroll : MonoBehaviour 
{
    Vector3 scrollWindowSize;
    bool canScroll;

    public GameObject content;
    public Vector3 contentPos;
    SpriteRenderer contentRenderer;
    public float contentLength;

    private Vector3 mouseDisplacement; // Displacement of mouse holding from centre of window

    private void Start()
    {
        scrollWindowSize = GetComponent<Collider2D>().bounds.size;
        canScroll = false;

        contentRenderer = content.GetComponent<SpriteRenderer>();
        contentLength = contentRenderer.bounds.size.y;
        contentPos = content.transform.position;
    }

    // Called when user first clicks on collider
    private void OnMouseDown()
    {
        mouseDisplacement = content.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // object pos - mouse pos
        canScroll = true;

        UpdateContent();
    }

    private void OnMouseExit()
    {
        // Stop dragging when mouse leaves collider
        canScroll = false;
    }

    // Called when user drags mouse click over collider (title bar)
    void OnMouseDrag()
    {
        if (canScroll)
        {
            contentPos = content.transform.position;

            // get mouse position, and move object Y
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            contentPos.y = mousePos.y + mouseDisplacement.y;

            if (!OutOfBounds())
            {
                content.transform.position = contentPos;
                // move content to new position
            }
            // otherwise don't move because it will move content out of bounds
        }
    }

    public void UpdateContent()
    {
        contentLength = contentRenderer.bounds.size.y;
    }

    bool OutOfBounds()
    {
        // keep content within boundaries of sprite

        if (contentPos.y > transform.position.y - (scrollWindowSize.y / 2))
        {
            return true;
            //content.transform.position = new Vector3(contentPos.x, transform.position.y - (scrollWindowSize.y / 2) + (contentLength / 2), contentPos.z);
        }
        if (contentPos.y + contentLength < transform.position.y + (scrollWindowSize.y / 2))
        {
            return true;
            //content.transform.position = new Vector3(contentPos.x, transform.position.y + (scrollWindowSize.y / 2) - (contentLength / 2), contentPos.z);
        }

        return false;
    }
}
