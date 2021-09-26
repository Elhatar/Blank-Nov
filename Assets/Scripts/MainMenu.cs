using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void begin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    public void close()
    {
        Application.Quit();
    }
}
