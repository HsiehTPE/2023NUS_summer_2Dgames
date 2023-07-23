using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu = null;
    private bool pauseflag = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pauseflag)
            {
                // print("p2"+pauseflag);
                // PauseGame();
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                pauseflag = true;
                // print("p2"+pauseflag);
            }
            else
            {
                // print("p1"+pauseflag);
                // ResumeGame();
                Time.timeScale = 1f;
                pauseflag = false;
                PauseMenu.SetActive(false);
                // print("p1"+pauseflag);
            }
        }
    }


    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseflag = true;
    }
 
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseflag = false;
        PauseMenu.SetActive(false);
    }

    public void click_unpause()
    {
        print("p3"+pauseflag);
        PauseMenu.SetActive(false);
        pauseflag = false;
        Time.timeScale = 1f;
        print("p3"+pauseflag);
    }
    // void enablePause()
    // {
    //     if(Input.GetKey(KeyCode.P) && !cooldown && !pauseflag)
    //     {
    //         PauseMenu.SetActive(true);
    //         Time.timeScale = 0f; 
    //         cooldown = true;
    //         pauseflag = true;
    //         mLastTriggered = Time.time;
    //         print("a");
    //         print(pauseflag);
    //     }
    //     print("a1");
    // }

    // void unablePause()
    // {
    //     if(Input.GetKey(KeyCode.P) && !cooldown && pauseflag)
    //     {
    //         PauseMenu.SetActive(false);
    //         Time.timeScale = 1f;
    //         cooldown = true;
    //         pauseflag = false;
    //         mLastTriggered = Time.time;
    //         print("b");
    //         print(pauseflag);
    //     }
    //     print("b1");
    // }

    // void check_cooldown()
    // {
    //     if(cooldown)
    //     {
    //         print("c");
    //         print(Time.time-mLastTriggered);
    //         if(Time.time - mLastTriggered >= mCoolDown)
    //             {cooldown = false;print("cooldown"+cooldown);}
    //     }
    //     print("c1");
    // }


}
