using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float speed = 1f; // tốc độ di chuyển của mặt đất
    [SerializeField]
    private Renderer renderer;

    void Update()
    {
        
        float offset = Time.time * speed; // tính offset dựa trên thời gian và tốc độ
        renderer.material.mainTextureOffset = new Vector2(offset, 0); // di chuyển ảnh theo offset
    }
}