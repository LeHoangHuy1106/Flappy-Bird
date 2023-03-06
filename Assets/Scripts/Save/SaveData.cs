using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static SaveData instance;

    public static SaveData Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Dữ liệu cần truyền giữa các scene
    public int dataToTransfer;

    // Hàm để lấy dữ liệu
    public int GetData()
    {
        return dataToTransfer;
    }

    // Hàm để thiết lập dữ liệu2
    public void SetData(int newData)
    {
        dataToTransfer = newData;
    }
}
