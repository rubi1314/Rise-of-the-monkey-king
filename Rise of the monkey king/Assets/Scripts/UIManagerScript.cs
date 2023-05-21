using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{

    public Image HealthImage1, HealthImage2, HealthImage3, HealthImage4, HealthImage5, 
    HealthImage6, Habilidad, Dialogo, Life30, Life29, Life28, Life27, Life26, Life25, Life24,
        Life23, Life22, Life21, Life20, Life19, Life18, Life17, Life16, Life15, Life14, Life13,
        Life12, Life11, Life10, Life9, Life8, Life7, Life6, Life5, Life4, Life3, Life2, Life1;


    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI;
    private float timeLeft = 2;
    public GameObject HUD;
    public Animator FundidoAnim;


    void Start()
    {
        //LoadValues();
        
        Dialogo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {        
        switch (PlayerScript.vidas)
        {
            case 6:              
                break;
            case 5:               
                HealthImage2.enabled = false;
                break;
            case 4:
                HealthImage2.enabled = false;
                HealthImage1.enabled = false;
                break;
            case 3:
                HealthImage2.enabled = false;
                HealthImage1.enabled = false;
                HealthImage4.enabled = false;
                break;
            case 2:
                HealthImage2.enabled = false;
                HealthImage1.enabled = false;
                HealthImage4.enabled = false;
                HealthImage3.enabled = false;
                break;
            case 1:
                HealthImage2.enabled = false;
                HealthImage1.enabled = false;
                HealthImage4.enabled = false;
                HealthImage3.enabled = false;
                HealthImage6.enabled = false;
                break;
            case 0:
                HealthImage2.enabled = false;
                HealthImage1.enabled = false;
                HealthImage4.enabled = false;
                HealthImage3.enabled = false;
                HealthImage6.enabled = false;
                HealthImage5.enabled = false;
                break;
            default:                
                break;
        }

        if (SceneManager.GetActiveScene().name == "Boss")
        {
            switch (dragonScript.vidas)
            {
                case 30:
                    break;
                case 29:
                    Life30.enabled = false;
                    break;
                case 28:
                    Life29.enabled = false;
                    break;
                case 27:
                    Life28.enabled = false;
                    break;
                case 26:
                    Life27.enabled = false;
                    break;
                case 25:
                    Life26.enabled = false;
                    break;
                case 24:
                    Life25.enabled = false;
                    break;
                case 23:
                    Life24.enabled = false;
                    break;
                case 22:
                    Life23.enabled = false;
                    break;
                case 21:
                    Life22.enabled = false;
                    break;
                case 20:
                    Life21.enabled = false;
                    break;
                case 19:
                    Life20.enabled = false;
                    break;
                case 18:
                    Life19.enabled = false;
                    break;
                case 17:
                    Life18.enabled = false;
                    break;
                case 16:
                    Life17.enabled = false;
                    break;
                case 15:
                    Life16.enabled = false;
                    break;
                case 14:
                    Life15.enabled = false;
                    break;
                case 13:
                    Life14.enabled = false;
                    break;
                case 12:
                    Life13.enabled = false;
                    break;
                case 11:
                    Life12.enabled = false;
                    break;
                case 10:
                    Life11.enabled = false;
                    break;
                case 9:
                    Life10.enabled = false;
                    break;
                case 8:
                    Life9.enabled = false;
                    break;
                case 7:
                    Life8.enabled = false;
                    break;
                case 6:
                    Life7.enabled = false;
                    break;
                case 5:
                    Life6.enabled = false;
                    break;
                case 4:
                    Life5.enabled = false;
                    break;
                case 3:
                    Life4.enabled = false;
                    break;
                case 2:
                    Life3.enabled = false;
                    break;
                case 1:
                    Life2.enabled = false;
                    break;
                case 0:
                    Life1.enabled = false;
                    break;

                default:
                    break;
            }
        }

        if (PlayerScript.vidas <= 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = 2;
                if(SceneManager.GetActiveScene().name == "SampleScene")
                {
                    SceneManager.LoadScene("Muerte");
                }

                if (SceneManager.GetActiveScene().name == "Boss")
                {
                    SceneManager.LoadScene("MuerteBoss");
                    dragonScript.vidas = 30;
                }

                PlayerScript.vidas = 6;
            }
        }

        if (dragonScript.vidas <=0)
        {
            HUD.SetActive(false);
            FundidoAnim = GameObject.Find("FundidoBlanco").GetComponent<Animator>();
            FundidoAnim.Play("FundidoBlanco");
        }

        if (DoorScript.open == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Boss");
            PlayerScript.vidas = 6;
        }

        if (teclaEScript.Habilidad == true &&  Input.GetKeyDown(KeyCode.E))
        {
            //UIHabilidad.enabled = true;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Exit()
    {
        Application.Quit();
    }

 
    /*public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();        
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }*/

    public void Boss()
    {
        SceneManager.LoadScene("Boss");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
