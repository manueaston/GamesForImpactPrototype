using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaFeed : MonoBehaviour
{
    public Sprite testSprite;
    public Sprite[] posts;
    public Sprite currentFeed;
    public Texture2D newFeed;
    SpriteRenderer contentRenderer;

    private void Start()
    {
        contentRenderer = GetComponent<SpriteRenderer>();
        contentRenderer.sprite = testSprite;

        currentFeed = testSprite;


        NewPost();
    }


    public void NewPost()
    {
        // Choose random post sprite from array
        AddSprite(testSprite);

        currentFeed = Sprite.Create(newFeed, new Rect(0, 0, newFeed.width, newFeed.height), Vector2.zero);
        contentRenderer.sprite = currentFeed;


        // Add sprite onto existing post feed

        // Update Scroll Content
    }

    void AddSprite(Sprite newPost)
    {

        for (int x = 0; x < newPost.texture.width; x++)
        {
            for (int y = 0; y < newPost.texture.height; y++)
            {
                newFeed.SetPixel(x, y, newPost.texture.GetPixel(x, y));
            }
        }
        for (int x = 0; x < currentFeed.texture.width; x++)
        {
            for (int y = 0; y < currentFeed.texture.height; y++)
            {
                newFeed.SetPixel(x, y + newPost.texture.height, currentFeed.texture.GetPixel(x, y));
            }
        }

        newFeed.Apply();
        
    }

}
