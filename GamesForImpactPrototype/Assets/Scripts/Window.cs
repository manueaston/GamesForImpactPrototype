using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Window : MonoBehaviour
{
    private Vector3 mouseDisplacement; // Displacement of mouse holding from centre of window
    // Stores displacement needed to stop window centre from snapping to mouse when being dragged

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when user first clicks on collider
    private void OnMouseDown()
    {
        mouseDisplacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // window pos - mouse pos
    }

    // Called when user drags mouse click over collider (title bar)
    void OnMouseDrag()
    {
        // get mouse position, and move window X and Y (not Z)
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + mouseDisplacement.x, mousePos.y + mouseDisplacement.y, transform.position.z); // Adds mouse displacement in x and y dimensions
    }
}
