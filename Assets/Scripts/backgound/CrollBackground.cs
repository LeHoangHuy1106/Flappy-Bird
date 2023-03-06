using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrollBackground : MonoBehaviour
{

    public float scrollSpeed = 0.5f;  
    [SerializeField]// Tốc độ cuộn
    private RawImage rawImage;          // Biến để lưu trữ RawImage của background
    private float offset;               // Biến để lưu trữ offset của background


    void Update()
    {
        // Tính toán offset mới dựa trên thời gian
        offset += Time.deltaTime * scrollSpeed;
        // Nếu offset vượt quá giới hạn 1.0, ta giảm nó xuống 1.0 để tạo hiệu ứng lặp lại
        if (offset > 1.0f)
        {
            offset -= 1.0f;
        }
        // Thiết lập thông số UVRect mới
        rawImage.uvRect = new Rect(offset, 0, 1, 1);
    }
}
