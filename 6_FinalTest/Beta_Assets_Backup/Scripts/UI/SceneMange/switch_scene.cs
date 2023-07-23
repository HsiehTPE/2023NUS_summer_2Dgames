using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_scene : MonoBehaviour
{
    // public opening_transition o;
    // Start is called before the first frame update
    public Animator transitionAnim;
    public string sceneName;
    public string scene_main;
    // public string scene_level_one;
    public string scene_snow;

    void Start()
    {
 
    }
 
    // Update is called once per frame
    void Update()
    {
 
    }

    public void startload()
    {
        StartCoroutine(LoadScene());
    }

    public void startmain()
    {
        Time.timeScale = 1f; 
        StartCoroutine(LoadMain());
    }

    public void startsnow()
    {
        // Time.timeScale = 1f; 
        StartCoroutine(LoadSnow());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadMain()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_main);
    }

    IEnumerator LoadSnow()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_snow);       
    }


    public void change_scene_main()
    {
        SceneManager.LoadScene("Main");
    }

    public void change_scene_village()
    {
        SceneManager.LoadScene("origin_villiage");
    }

    public void change_to_levelone()
    {
        SceneManager.LoadScene("level_one");
    }

    public void quit_game()
    {
        //编辑器中退出游戏
        #if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
        //应用程序中退出游戏
        #else 
            UnityEngine.Application.Quit();
        #endif
    }
}