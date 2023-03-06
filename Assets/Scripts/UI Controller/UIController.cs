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

    [SerializeField]
    private Slider slider;

    float volumn;

 

    




    private void Start()
    {

        volumn  = PlayerPrefs.GetFloat("volumn", 0);
        if (slider)
        {
            slider.value = volumn;
        }
        if (birds[0])
        {
            changeColor(0, 1);
            for (int i = 1; i <= 5; i++)
            {
                changeColor(i, 0);
            }
        }

    }
    private void Update()
    {
        if (slider)
        {
            PlayerPrefs.SetFloat("volumn", slider.value);
            AudioListener.volume = slider.value;


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


    public  void bird0()
    {

        changeColor(indexChoose, 0);
        indexChoose = 0;
        changeColor(indexChoose, 1);
    }
    public void bird1()
    {
        changeColor(indexChoose, 0);
        indexChoose = 1;
        changeColor(indexChoose, 1);


    }
    public void bird2()
    {
        changeColor(indexChoose, 0);
        indexChoose = 2;
        changeColor(indexChoose, 1);
    }
    public void bird3()
    {
        changeColor(indexChoose, 0);
        indexChoose = 3;
        changeColor(indexChoose, 1);
    }
    public void bird4()
    {
        changeColor(indexChoose, 0);
        indexChoose = 4;
        changeColor(indexChoose, 1);
    }
    public void bird5()
    {
        changeColor(indexChoose, 0);
        indexChoose = 5;
        changeColor(indexChoose, 1);
    }

    public void OptionBird()
    {
        Application.LoadLevel("OptionMenu");

    }
    public void     PlayGame()
    {

  
        SaveData.Instance.SetData(indexChoose);

        Application.LoadLevel("SampleScene");

    }


    
    public void OpenGame()
    {
        Application.LoadLevel("OpenScene");

    }




}
