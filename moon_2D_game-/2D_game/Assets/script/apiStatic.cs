using UnityEngine;

public class apiStatic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float a;
        float b;
        float num;
        print(Mathf.PI);
        Time.timeScale = 0.5f;
        print(Random.value);
        a = Mathf.Abs(-500);
        print(a);
        b = Random.Range(25.6f, 50.5f);
        int count = Camera.allCameras.Length;
        print(count + " cameras");
        Cursor.visible = false;
        //Application.OpenURL("https://store.steampowered.com/l");
        num = Mathf.Floor(123.567f);
        print(num);
    }
    private void Update()
    {
        print("是否輸入任意鍵:" + Input.anyKey);
      
    }


}
