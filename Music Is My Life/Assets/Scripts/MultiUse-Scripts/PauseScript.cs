using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pausePanel;
    public GameObject AudioManager;
    private AudioSource audioSource;
    private GameObject smartPhonePanel;
    private Toggle smartPhoneBtn;
    private GameObject SNSPanel;
    private GameObject FortuneOpenPanel;
    private GameObject FortuneContentPanel;

    
    void Start()
    {
        audioSource = AudioManager.GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();
        
        if (scene.name == "Main"){

            smartPhonePanel = GameObject.Find("MainRoom뷰").transform.GetChild(3).gameObject;
            GameObject Btn = GameObject.Find("스마트폰버튼");
            smartPhoneBtn = Btn.GetComponent<Toggle>();

            SNSPanel = GameObject.Find("SNS-Panel");
        }

        else if (scene.name == "Main-Fortune"){
            SNSPanel = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
            FortuneOpenPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
            FortuneContentPanel = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        }
    }

    void Update()
    {   
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(smartPhonePanel != null && smartPhonePanel.activeSelf){
                smartPhonePanel.SetActive(false);
                smartPhoneBtn.isOn = false;
                return;
            }

            if(SNSPanel != null && SNSPanel.activeSelf){
                SNSPanel.SetActive(false);
                return;
            }

            if(FortuneOpenPanel != null && FortuneOpenPanel.activeSelf){
                FortuneOpenPanel.SetActive(false);
                return;
            }

            if(FortuneContentPanel != null && FortuneContentPanel.activeSelf){
                FortuneContentPanel.SetActive(false);
                return;
            }

            if (scene.name == "Main-Fortune"){
                SceneManager.LoadScene("Main");
                return;
            }

            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        audioSource.UnPause();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        audioSource.Pause();
    }
}
