using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour {

    public GameObject EscapeMenuPanel;
    public GameObject movement;
    public GameObject HelpMenu;
    public GameObject Camera;

    private void Start()
    {
        HelpMenu.SetActive(false);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && EscapeMenuPanel.activeSelf)
        {
            movement.SetActive(true);
            EscapeMenuPanel.SetActive(false);
            Camera.SetActive(true);
        }
    }

    public void Continue()
    {
        movement.SetActive(true);
        EscapeMenuPanel.SetActive(false);
        Camera.SetActive(true);
    }

    public void Help()
    {
        //EscapeMenuPanel.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void HelpBack()
    {
        HelpMenu.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
