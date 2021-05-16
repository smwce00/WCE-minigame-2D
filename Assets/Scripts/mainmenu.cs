using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void StartGame1()
    {
        SceneManager.LoadScene("2DMovement");

    }
    public void StartGame2()
    {
        SceneManager.LoadScene("2DHPBar");

    }

    public void StartGame3()
    {
        SceneManager.LoadScene("2DCooldown");

    }
}
