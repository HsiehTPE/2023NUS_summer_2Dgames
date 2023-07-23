using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class opening_tansition : MonoBehaviour
{
    public bool T = false;

    Animator Anime;

    // Start is called before the first frame update
    void Start()
    {
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(T)
        {
            Anime.Play("normal_transitions");
            // T = false;
        }
    }



    public void change_scene_village()
    {
        SceneManager.LoadScene("origin_villiage");
    }

    public void opening_trigger()
    {
       T = true;
    }

    // public void quit_game()
    // {
    //     //编辑器中退出游戏
    //     #if UNITY_EDITOR 
    //         UnityEditor.EditorApplication.isPlaying = false;
    //     //应用程序中退出游戏
    //     #else 
    //         UnityEngine.Application.Quit();
    //     #endif
    // }
}
