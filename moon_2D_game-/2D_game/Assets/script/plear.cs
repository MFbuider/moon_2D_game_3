
using UnityEngine;

/// <summary>
/// 移動
/// </summary>
public class plear : MonoBehaviour
{
    [Header("速度"), Tooltip("用來設定移動的速度。")]
    public float speed = 10.5f;[Range(0, 1000)]
    [Header("跳躍"), Tooltip("用來設定跳躍的高度。")]
    public float jump = 100f;[Range(0, 3000)]
    public bool floor = false;
    int score = 0;     
    public GameObject bullet;
    public GameObject 子彈生成點;
    public float Movingpeed = 800f;[Range(0, 5000)]
    public AudioClip bulletAU;
    public int lives = 3;[Range(0, 5)]
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        Move();   
    }
    private void Move()
    {
        float L = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(L * speed, rig.velocity.y);
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    public void jump2()
    {
   
    }
    /// <summary>
    /// 開槍
    /// </summary>
    public void fire()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
