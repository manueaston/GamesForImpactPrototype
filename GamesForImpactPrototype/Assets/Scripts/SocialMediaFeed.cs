using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaFeed : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;

    public Sprite[] posts;
    public Sprite currentFeed;
    float numPosts = 1.0f;
    Vector3 postSize;
    SpriteRenderer contentRenderer;

    private void Start()
    {
        contentRenderer = GetComponent<SpriteRenderer>();
        currentFeed = contentRenderer.sprite;
        postSize = contentRenderer.bounds.size; // world size of single post

        StartCoroutine(WaitForNextPost());
    }

    private void Awake()
    {
        Debug.Log("Awake");
    }

    IEnumerator WaitForNextPost()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        // Waits for a random number of seconds between min and max wait time before creating a new post

        NewPost();
        StartCoroutine(WaitForNextPost()); // Calls self at end to keep creating new posts
    }

    public void NewPost()
    {
        numPosts++;

        // Choose random post sprite from array
        int newPostIndex = Random.Range(0, posts.Length);

        // Add new post sprite to feed
        AddSprite(posts[newPostIndex]);
    }

    void AddSprite(Sprite newPost)
    {
        int currentWidth = currentFeed.texture.width;
        int currentHeight = currentFeed.texture.height;
        int postWidth = newPost.texture.width;
        int postHeight = newPost.texture.height;

        var newFeed = new Texture2D(currentWidth, currentHeight + postHeight);

        for (int x = 0; x < postWidth; x++)
        {
            for (int y = 0; y < postHeight; y++)
            {
                newFeed.SetPixel(x, y, newPost.texture.GetPixel(x, y));
            }
        }
        for (int x = 0; x < currentWidth; x++)
        {
            for (int y = 0; y < currentHeight; y++)
            {
                newFeed.SetPixel(x, y + postHeight, currentFeed.texture.GetPixel(x, y));
            }
        }

        newFeed.Apply();
        currentFeed = Sprite.Create(newFeed, new Rect(0, 0, newFeed.width, newFeed.height), new Vector2(0, 0));
        contentRenderer.sprite = currentFeed;

        //Vector3 currentPos = gameObject.transform.position;
        //gameObject.transform.position = new Vector3(currentPos.x, currentPos.y + postSize.y / 2.0f, currentPos.z);
    }

}
