using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Game Manager is static, can be accessed anywhere

    ButtonMain[] buttons;
    int buttonsActive;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject); // persists through scenes
    }

    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectsOfType<ButtonMain>();

        InvokeRepeating("ActivateRandomButton", 1.0f, 1.0f); // active random button every 0.25 seconds after an intial time of 1 second
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateRandomButton()
    {
        if (buttonsActive < buttons.Length) // Does not execute if all buttons are activated
        {
            ButtonMain selectedButton = buttons[Random.Range(0, buttons.Length)]; // Choose random button in array

            if (selectedButton.IsActive())
            {
                // Select other button
                ActivateRandomButton();
            }
            else
            {
                selectedButton.Activate();
                buttonsActive++;
            }
        }
    }

    public void ButtonDeactivated()
    {
        buttonsActive--;
    }
}
