using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailWindow : Window
{
    void Start()
    {
        // hide the window
        transform.localScale = new Vector3(0, 0, 0);
    }
}