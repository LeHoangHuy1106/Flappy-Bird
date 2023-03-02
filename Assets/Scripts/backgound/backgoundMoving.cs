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

    int count = 0;
    bool Checkcore = true;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Conllider();



    }

    void Moving()
    {
        temp = transform.localPosition;
        temp.x = temp.x - speed;
        if (temp.x <= -16)
        {
            transform.localPosition = new Vector2(18, 0);
            RandomChimney();
        }
        else
        {
            transform.localPosition = temp;
        }

    }
    void RandomChimney()
    {
        if (checkChimney)
        {
            i = Random.Range(3.0f, -1.0f);
            Vector2 pos = transform.localPosition;
            pos.y = i;
            transform.localPosition = pos;


        }

    }

    void Conllider()
    {
        if (player)
        {
            if (transform.localPosition.x <= -8 && transform.localPosition.x >= -10)
            {
                Debug.Log("đi qua x");
                if (player.localPosition.y > transform.localPosition.y - 1.2f && player.localPosition.y < transform.localPosition.y + 1.2f)
                {
                    Debug.Log("đi qua y");
                   
                    if (text ) 
                    {
                        audio.clip = clip;
                        audio.Play();
                       

                    }

                }
                else
                {
                    audio.clip = clipD;
                    audio.Play();
                    Time.timeScale = 0;
             
                }

            }

            if (player.localPosition.y < -2.6f && player.localPosition.y > 4.6f)
            {
                Time.timeScale = 0;
                audio.clip = clipD;
                audio.Play();
               

            }



        }
    }

}
