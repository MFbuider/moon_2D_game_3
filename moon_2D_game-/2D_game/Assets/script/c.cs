using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c : MonoBehaviour
{
    [Header("cc"), Tooltip("用來設定cc的。")]
    [Range(0, 3000)]
    public int cc = 3000;
public float g = 1000f;[Range(0, 5000)]
    public  string a = "bc";
    public bool haveatree = true;
    public Color red = Color.red;
    public Color clorw = new Color(0, 2, 0);
   public Vector2 v2 = Vector2.one;
   public Vector3 v3 = Vector3.one;
   public Vector4 v4 = Vector4.one;
   public GameObject obj;
   public Terrain tr;
   public SpriteRenderer sr ;

    private void Start()
    {
        print("HiPlear");
    }

    private void Update()
    {
        print("Update");
    }
    
}
