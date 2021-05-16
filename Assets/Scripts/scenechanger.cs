using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void SceneChangetoN_HP()
    {
        SceneManager.LoadScene("2DHPBar");

    }
    public void SceneChangetoN_move()
    {
        SceneManager.LoadScene("2DMovement");

    }

    public void SceneChangetoN_skill()
    {
        SceneManager.LoadScene("2DCooldown");

    }

    //ÇÙÀû¿ë
    public void SceneChangetoHPHack()
    {
        SceneManager.LoadScene("2DHPBarHack");

    }

    public void SceneChangetoMoveHack()
    {
        SceneManager.LoadScene("2DMovementHack");

    }


    public void SceneChangetoSkillHack()
    {
        SceneManager.LoadScene("2DCooldownHack");

    }

    public void SceneChangetoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
