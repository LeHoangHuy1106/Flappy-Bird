using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed = 5f; // Vận tốc nhảy
    public float g = 9.8f; // Gia tốc trọng trường
    private float verticalVelocity = 0f; // Vận tốc theo trục y

    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioSource audio;


    void Update()
    {
      
        if (Input.GetMouseButtonDown(0)) 
        {
            audio.clip = clip;
            audio.Play();
            verticalVelocity = jumpSpeed;
            transform.rotation = Quaternion.Euler(0, 30, 0);
        }
        else
        {
            verticalVelocity -= g * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -30, 0);
        }

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y + verticalVelocity * Time.deltaTime,-3,5)); // Cập nhật vị trí của đối tượng
    }


}
