using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Button[] birds = new Button[6];
    int indexChoose;



    float volumn;
    [SerializeField]
    GameObject panel;

    [SerializeField]
    AudioSource audioEffect, audioBackground;
    [SerializeField]
    AudioClip clip;

    [SerializeField] SaveData data;



    void EffectButton()
    {
        audioEffect.clip = clip;
        audioEffect.Play();
    }

 

    




    private void Start()
    {



        if (birds[0])
        {
            changeColor(0, 1);
            for (int i = 1; i <= 5; i++)
            {
                changeColor(i, 0);
            }
        }

       

    }



    void changeColor(int i, int check)
    {

        ColorBlock colors = birds[i].colors;
        if (check == 0)
        {

            colors.normalColor = new Color(colors.normalColor.r, colors.normalColor.g, colors.normalColor.b, 0.4f);
        }
        else if (check == 1)
        {
            colors.normalColor = new Color(colors.normalColor.r, colors.normalColor.g, colors.normalColor.b, 1f);
        }    
            birds[i].colors = colors;
    }

   






    public void SaveVolumn()
    {
        PlayerPrefs.SetFloat("VLBackground",audioBackground.volume);
        PlayerPrefs.SetFloat("VLEffect", audioEffect.volume);

        PlayerPrefs.Save();
        panel.active = !panel.active;
        EffectButton();
    }

    [SerializeField]
    Slider sdEffect, sdBackground;
    float tempVLEffect, tempVLBackground;

    public void ResetVolumn()
    {
         sdEffect.value = tempVLEffect;
        sdBackground.value = tempVLBackground ;

        EffectButton();

    }
  

    public void SettingPanel()
    {
        EffectButton();
        panel.active = !panel.active;

            tempVLEffect = sdEffect.value;
            tempVLBackground = sdBackground.value;


    }

    public  void bird0()
    {
        EffectButton();
        changeColor(indexChoose, 0);
        indexChoose = 0;
        changeColor(indexChoose, 1);
    }
    public void bird1()
    {
        EffectButton();
        changeColor(indexChoose, 0);
        indexChoose = 1;
        changeColor(indexChoose, 1);


    }
    public void bird2()
    {
        EffectButton();
        changeColor(indexChoose, 0);
        indexChoose = 2;
        changeColor(indexChoose, 1);
    }
    public void bird3()
    {
        EffectButton();
        changeColor(indexChoose, 0);
        indexChoose = 3;
        changeColor(indexChoose, 1);
    }
    public void bird4()
    {
        EffectButton();
        changeColor(indexChoose, 0);
        indexChoose = 4;
        changeColor(indexChoose, 1);
    }
    public void bird5()
    {
        EffectButton();
        changeColor(indexChoose, 0);
        indexChoose = 5;
        changeColor(indexChoose, 1);
    }

    public void OptionBird()
    {
        EffectButton();
        Application.LoadLevel("OptionMenu");

    }
    public void     PlayGame()
    {

        EffectButton();
            SaveData.Instance.SetData(indexChoose);
     //   data.SetIndex(indexChoose);

        Application.LoadLevel("SampleScene");

    }


    
    public void OpenGame()
    {
        EffectButton();
        Application.LoadLevel("OpenScene");

    }






}
