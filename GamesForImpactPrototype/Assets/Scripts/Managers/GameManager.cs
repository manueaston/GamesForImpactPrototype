using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Game Manager is static, can be accessed anywhere

    ButtonMain[] buttons;
    int buttonsActive;
    public static int buttonPresses = 0;
    public TextMeshProUGUI buttonTxt;
    public GameObject endScreen;
    public float buttonSpeed;

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

        InvokeRepeating("ActivateRandomButton", 3.0f, buttonSpeed); // active random button every buttonSpeed seconds after an intial time of 3 seconds
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
        yield return new WaitForSeconds(150.0f);
        
        buttonTxt.text = buttonPresses.ToString();
        endScreen.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(0);
    }
}
