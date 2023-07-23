using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class east_npc : MonoBehaviour
{
    public string[] sentences; 
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject TextPlane;
    public TextMeshProUGUI textDisplay;
    public AudioClip[] myAudioclip;
    AudioSource myAudio;
    private bool first = false;
    IEnumerator Type()
    {
        // index = 0;
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length-1)
        {
            index ++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
                textDisplay.text = "";
                continueButton.SetActive(false);
                TextPlane.SetActive(false);
                // 2
                // Time.timeScale = 1f; 
        }
    }

    void OnEnable()
    {
        index = 0;
        StartCoroutine(Type());
        // index = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                // if(!first)
                // {
                    myAudio.PlayOneShot(myAudioclip[1]);
                    first = true;
                // }
                NextSentence();
            }
        }
    }
}
