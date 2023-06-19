using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject advertWindow;
    public GameObject chatNotifWindow;
    public GameObject smNotifWindow;
    public GameObject emailNotifWindow;

    public float adRateLowerLimit; // The minimum amount of time to pass before a new ad can be created
    public float adRateUpperLimit; // The maximum amount of time that can pass before a new ad is created
    float adCountdown = 0.0f;

    public float chatRateLowerLimit; // The minimum amount of time to pass before a new chat message
    public float chatRateUpperLimit; // The maximum amount of time that can pass before a new chat message
    float chatCountdown = 0.0f;

    public float smRateLowerLimit; // The minimum amount of time to pass before a new social media post
    public float smRateUpperLimit; // The maximum amount of time that can pass before a new social media post
    float smCountdown = 0.0f;

    public float emailRateLowerLimit; // The minimum amount of time to pass before a new social media post
    public float emailRateUpperLimit; // The maximum amount of time that can pass before a new social media post
    float emailCountdown = 0.0f;

    float debugTimer = 0.0f; // For debug purposes


    // Start is called before the first frame update
    void Start()
    {
        GetNextAdCountdown();
        GetNextChatCountdown();
        GetNextSMCountdown();
        GetNextEmailCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        // Ad countdown/instantiation
        adCountdown -= Time.deltaTime;

        if (adCountdown <= 0.0f)
        {
            Debug.Log("Spawn Ad After " + debugTimer + " Seconds");
            CreateNewAd();

            GetNextAdCountdown();
        }

        // Chat window countdown/instantiation
        chatCountdown -= Time.deltaTime;

        if (chatCountdown <= 0.0f)
        {
            Debug.Log("Spawn Chat Notification After " + debugTimer + " Seconds");
            CreateNewChat();

            GetNextChatCountdown();
        }

        // Social media window countdown/instantiation
        smCountdown -= Time.deltaTime;

        if (smCountdown <= 0.0f)
        {
            Debug.Log("Spawn SM Notification After " + debugTimer + " Seconds");
            CreateNewSM();

            GetNextSMCountdown();
        }

        // Email window countdown/instantiation
        emailCountdown -= Time.deltaTime;

        if (emailCountdown <= 0.0f)
        {
            Debug.Log("Spawn Email Notification After " + debugTimer + " Seconds");
            CreateNewEmail();

            GetNextEmailCountdown();
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

    void GetNextChatCountdown() // Get amount of time to wait before next chat notification is created
    {
        chatCountdown = Random.Range(chatRateLowerLimit, chatRateUpperLimit);
        debugTimer = chatCountdown;
    }

    void CreateNewChat()
    {
        // Instantiate chat window at bottom left
        Instantiate(chatNotifWindow, Camera.main.ScreenToWorldPoint(new Vector3(150.0f, 120.0f, 100.0f)), Quaternion.identity);
    }
    
    void GetNextSMCountdown() // Get amount of time to wait before next social media notification is created
    {
        smCountdown = Random.Range(smRateLowerLimit, smRateUpperLimit);
        debugTimer = smCountdown;
    }

    void CreateNewSM()
    {
        // Instantiate social media notification at top left
        Instantiate(smNotifWindow, Camera.main.ScreenToWorldPoint(new Vector3(100.0f, Camera.main.pixelHeight - 120.0f, 100.0f)), Quaternion.identity);
    }

    void GetNextEmailCountdown() // Get amount of time to wait before next email notification is created
    {
        emailCountdown = Random.Range(emailRateLowerLimit, emailRateUpperLimit);
        debugTimer = emailCountdown;
    }

    void CreateNewEmail()
    {
        // Instantiate email notification at top right
        Instantiate(emailNotifWindow, Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth - 150.0f, Camera.main.pixelHeight - 120.0f, 100.0f)), Quaternion.identity);
    }
}
