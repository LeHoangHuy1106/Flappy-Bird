using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgoundMoving : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Vector2 temp;
    [SerializeField]
    bool checkChimney = false;
    float i;

    [SerializeField]
    AudioClip clip, clipD;

    [SerializeField]
    AudioSource audio;


    [SerializeField]
    Text text;

    [SerializeField]
    Transform player;

    [SerializeField]
    GameObject panelGameOver;

    [SerializeField]
    GameObject chimneies;



    private int score = 0, best;

    int tempScore;

    private float verticalVelocity = 0f;


    bool checkPlayer;

    [SerializeField]
    Text txtMyCore;
    [SerializeField]
    Text txtBest;

    bool start = true;



    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0;
        Input.simulateMouseWithTouches = true;
        if (panelGameOver)
        {

            panelGameOver.active = false;
        }
        checkPlayer = true;
        setScore(0);
        speed = 0.0f;



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && start == true)
        {
            start = false;
            speed = 0.022f;
        }

        if (checkPlayer == true)
        {

            Moving(speed);
            Conllider();
            Score();
        }
        else
        {
            Death();
        }




    }


    void Moving(float speed)
    {
        temp = transform.localPosition;
        temp.x = temp.x - speed;
        if (temp.x <= 0)
        {
            i = Random.Range(-1.5f, 1.5f);
            transform.localPosition = new Vector2(12, i);
            tempScore = 1;
     
        }
        else
        {
            transform.localPosition = temp;
        }

    }


    void Score()
    {
        if (transform.localPosition.x >=6)
        {
            tempScore = 1;

        }
        else
        {

            setScore(getScore() + tempScore);
            ; if (text)
            {
                text.text = getScore() + "";
            }
            tempScore = 0;
        }

    }

    void Conllider()
    {
        if (player)
        {
           
            if (transform.localPosition.x <= 5.6f && transform.localPosition.x >= 4.3f)
            {
                Debug.Log("đi qua x");
                if (player.localPosition.y > transform.localPosition.y - 1.675f && player.localPosition.y < transform.localPosition.y + 1.675f)
                {
                    Debug.Log("đi qua y");

                    if (text)
                    {
                        audio.clip = clip;
                        audio.Play();
                    }

                }
                else
                {
                    audio.clip = clipD;
                    audio.Play();

                    if (panelGameOver)
                    {

                        panelGameOver.active = true;

                    }
                    checkPlayer = false;



                }

            }

            if (player.localPosition.y < -3.6f && player.localPosition.y > 4.6f)
            {

                audio.clip = clipD;
                audio.Play();
                if (panelGameOver)
                {
                    panelGameOver.active = true;
                }
                checkPlayer = false;


            }



        }
    }

    int getScore()
    {
        score = PlayerPrefs.GetInt("score", 0);
        return score;
    }
    void setScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }


    int GetBest()
    {
        int best = PlayerPrefs.GetInt("best", 0);
        return best;
    }

    void SetBest()
    {
        if (getScore() > GetBest())
        {
            PlayerPrefs.SetInt("best", score);
        }
        return;
    }

    void Death()
    {

        SetBest();
        setTextGameOver();
        verticalVelocity -= 6 * Time.deltaTime;
        Input.simulateMouseWithTouches = false;
        player.transform.position = new Vector2(player.transform.position.x, Mathf.Clamp(player.transform.position.y + verticalVelocity * Time.deltaTime, player.transform.position.y, 6)); // Cập nhật vị trí của đối tượng

        if (player.transform.localPosition.y <= -3.4)
        {
            Time.timeScale = 0;
        }
        if ( chimneies)
        {
            chimneies.active = false;
        }    
        


       



    }

    void setTextGameOver()
    {
        if (txtBest && txtMyCore)
        {
            txtBest.text = GetBest() + "";
            txtMyCore.text = getScore() + "";
        }
    }


}