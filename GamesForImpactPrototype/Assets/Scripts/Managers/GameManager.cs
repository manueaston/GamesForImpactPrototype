using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Game Manager is static, can be accessed anywhere

    ButtonMain[] buttons;
    int buttonsActive;
    public static int buttonPresses = 0;
    public TextMeshProUGUI buttonTxt;
    public GameObject endScreen;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject); // persists through scenes

        // find button count text
        buttonTxt = FindObjectOfType<TextMeshProUGUI>();
        StartCoroutine("EndGame");
    }

    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectsOfType<ButtonMain>();

        InvokeRepeating("ActivateRandomButton", 1.0f, 1.0f); // active random button every 0.25 seconds after an intial time of 1 second
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

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(90.0f);
        
        buttonTxt.text = buttonPresses.ToString();
        endScreen.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
