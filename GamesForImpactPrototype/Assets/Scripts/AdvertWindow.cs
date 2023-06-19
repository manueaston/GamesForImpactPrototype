using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertWindow : Window
{
    public Sprite[] sprites = new Sprite[3];

    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, 3)];
    }
}
