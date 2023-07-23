using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public GameObject BagMenu = null;
    public Main_Charactor ango = null;
    public GameObject torch_button = null;
    private bool bagflag = false;
    public string currentSelectItem;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setCurrentItem(string name) {
        currentSelectItem = name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!bagflag)
            {
                print("p2"+bagflag);
                // PauseGame();
                BagMenu.SetActive(true);
                Time.timeScale = 0f;
                bagflag = true;
                print("p2"+bagflag);
            }
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            switch (currentSelectItem)
            {
                case "null_button":
                    ango.bag_null();
                    break;
                case "sword_button":
                    ango.bag_sword();
                    break;
                case "torch_button":
                    ango.bag_torch();
                    break;
                default: break;
            }
            print("p1"+bagflag);
            // ResumeGame();
            Time.timeScale = 1f;
            bagflag = false;
            BagMenu.SetActive(false);
            print("p1"+bagflag);
        }
        if(ango.get_torch)
        {
            torch_button.SetActive(true);
        }
    }


    public void PauseGame()
    {
        BagMenu.SetActive(true);
        Time.timeScale = 0f;
        bagflag = true;
    }
 
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        bagflag = false;
        BagMenu.SetActive(false);
    }

    public void click_unpause()
    {
        print("p3"+bagflag);
        BagMenu.SetActive(false);
        bagflag = false;
        Time.timeScale = 1f;
        print("p3"+bagflag);
    }
}
