using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {


    public GameObject BreadCrumbs;
    public Text BreadCrumbLeftNumber;
    public int NumberOfCrumbs;
    public Transform Player;
    Vector3 playerpos;
    

    public GameObject EscapeMenuPanel;
    public GameObject movement;
    public GameObject Camera;


    void Start()
    {
        BreadCrumbLeftNumber.text = NumberOfCrumbs.ToString();

    }
    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Escape) && !EscapeMenuPanel.activeSelf)
        {
            //Debug.Log("test");
            Invoke("SetEscapeMenuPanel",Time.deltaTime);
            movement.SetActive(false);
            Camera.SetActive(false);
        }

        if (Input.GetKeyDown("f") && NumberOfCrumbs>0)
        {
            playerpos.Set(Player.position.x, Player.position.y+1, Player.position.z);
            Instantiate(BreadCrumbs, playerpos, Quaternion.identity);
            NumberOfCrumbs--;
            BreadCrumbLeftNumber.text = NumberOfCrumbs.ToString();
            
        }

        if(Input.GetKeyDown("g"))
        {
            playerpos.Set(Player.position.x, Player.position.y + 1, Player.position.z);
            GameObject closest = FindClosestWithTag("BreadCrumb");


            if ((closest.transform.position-playerpos).sqrMagnitude<1.5)
            {
                Destroy(closest);
                NumberOfCrumbs++;
                BreadCrumbLeftNumber.text = NumberOfCrumbs.ToString();
                
            }
            
        }

        if (Input.GetKeyDown("e"))
        {
            playerpos.Set(Player.position.x, Player.position.y + 1, Player.position.z);
            GameObject closest= FindClosestWithTag("ClosedChest");

            if ((closest.transform.position - playerpos).sqrMagnitude < 3)
            {

                closest.GetComponent<Renderer>().enabled = false;

                closest = FindClosestWithTag("OpenedChest");
                closest.GetComponent<Renderer>().enabled = true;

                
                Invoke("DisableRendererCoins", 2);


                NumberOfCrumbs += 5;
                BreadCrumbLeftNumber.text = NumberOfCrumbs.ToString();
                
            }

        }
    }


    void SetEscapeMenuPanel()
    {
        EscapeMenuPanel.SetActive(true);
    }


    public GameObject FindClosestWithTag(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        //playerpos.Set(Player.position.x, Player.position.y + 1, Player.position.z);
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - playerpos;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        
        return closest;
    }

    void DisableRendererCoins()
    {
        GameObject closest = FindClosestWithTag("Coins");
        closest.GetComponent<Renderer>().enabled = false;
    }
}
