using UnityEngine;

public class FinishScript : MonoBehaviour {

    public GameManager gamemanager;

    void OnTriggerEnter()
    {
        gamemanager.FinishLevel();
    }
}
