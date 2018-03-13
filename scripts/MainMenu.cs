using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public GameObject HelpMenu;
    public GameObject PlayMenu;
    public GameObject[] WallPrefab;

    public void StartGame()
    {
        PlayMenu.SetActive(true);
    }

    public void Help()
    {
        HelpMenu.SetActive(true);
    }

	public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        HelpMenu.SetActive(false);
    }

    public void HighWall()
    {
        if (WallPrefab[0].transform.lossyScale.y==1.5)
        {
            for(int i=0;i<4;i++)
            {
                WallPrefab[i].transform.localScale += new Vector3(0, 2.5F , 0);
            }
        }
        SceneManager.LoadScene(1);
    }

    public void NormalWall()
    {
        Debug.Log("1");
        if (WallPrefab[0].transform.lossyScale.y==4)
        {
            Debug.Log("2");
            for (int i = 0; i< WallPrefab.Length; i++)
            {
                Debug.Log("3");
                Debug.Log(WallPrefab[i].transform.localScale.y);
                WallPrefab[i].transform.localScale -= new Vector3(0, 2.5F, 0);
                Debug.Log(WallPrefab[i].transform.localScale.y);
            }
        }
        SceneManager.LoadScene(1);
    }
}
