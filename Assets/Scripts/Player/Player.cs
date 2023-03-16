using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float jumpSpeed = 5f; // Vận tốc nhảy
    float g = 9.8f; // Gia tốc trọng trường
    float verticalVelocity = 0f; // Vận tốc theo trục y
    float value;

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioSource audio;

    [SerializeField]
    private GameObject panelStart;

    [SerializeField]
    Animator anim;

    [SerializeField]
    RuntimeAnimatorController[] controller = new RuntimeAnimatorController[6];

    int index;

   


    public int count = 0;


    private void Start()
    {


        float volumn = PlayerPrefs.GetFloat("volumn", 0);
        AudioListener.volume = volumn;

        //    index = PlayerPrefs.GetInt("bird", 0);

            index = SaveData.Instance.GetData();
        



        anim.runtimeAnimatorController = controller[index];
        Time.timeScale = 0;
        panelStart.active = true;

    }

    void Update()
    {

       
        if (Input.GetMouseButtonDown(0)) 
        {
            Time.timeScale = 1;
            audio.clip = clip;
            audio.Play();
            verticalVelocity = jumpSpeed;



        }
        else
        {

            verticalVelocity -= g * Time.deltaTime;
        
        }

        Vector2 newVector = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y + verticalVelocity * Time.deltaTime, -3.3f, 4f));
        float scaledValue = 10 * (newVector.y - (-2.36f) / (4 - (-3.3f))) - 5;


        transform.rotation = Quaternion.Euler(0.0f, 0.0f, scaledValue);

        transform.position =newVector; // Cập nhật vị trí của đối tượng
    }




}
