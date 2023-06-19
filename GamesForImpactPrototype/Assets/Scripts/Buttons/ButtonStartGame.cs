using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStartGame : ButtonParent
{
    public override void ButtonPressed()
    {
        Debug.Log("Game started!");
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
