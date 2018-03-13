using UnityEngine;


public class GameManager : MonoBehaviour {


    public GameObject LevelWonUI;

    public void FinishLevel()
    {
        LevelWonUI.SetActive(true);
    }
    

}
