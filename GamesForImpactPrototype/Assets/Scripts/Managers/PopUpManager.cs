using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject advertWindow;

    public float adRateLowerLimit; // The minimum amount of time to pass before a new ad can be created
    public float adRateUpperLimit; // The maximum amount of time that can pass before a new ad is created

    float adCountdown = 0.0f;
    float debugTimer = 0.0f; // For debug purposes


    // Start is called before the first frame update
    void Start()
    {
        GetNextAdCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        adCountdown -= Time.deltaTime;

        if (adCountdown <= 0.0f)
        {
            Debug.Log("Spawn Ad After " + debugTimer + " Seconds");
            CreateNewAd();

            GetNextAdCountdown();
        }
    }

    void GetNextAdCountdown() // Get amount of time to wait before next ad is created
    {
        adCountdown = Random.Range(adRateLowerLimit, adRateUpperLimit);
        debugTimer = adCountdown;
    }

    void CreateNewAd()
    {
        // Get random position within camera
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

        Instantiate(advertWindow, new Vector2(spawnX, spawnY), Quaternion.identity);
    }
}
