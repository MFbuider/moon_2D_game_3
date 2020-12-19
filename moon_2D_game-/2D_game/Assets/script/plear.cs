
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// 移動
/// </summary>
public class plear : MonoBehaviour
{
    [Header("速度"), Tooltip("用來設定移動的速度。")]
    public float speed = 10.5f;[Range(0, 1000)]
    [Header("跳躍"), Tooltip("用來設定跳躍的高度。")]
    public float jump = 100f;
    [Header("是否在地板上"), Tooltip("用來儲存玩家是否站在地板上")]
    public bool floor = false;
    [Header("子彈"), Tooltip("存放要生成的子彈預製物")]
    public GameObject bullet;
    [Header("子彈生成點"), Tooltip("子彈要生成的起始位置")]
    public Transform point;
    public float Movingpeed = 800f;
    [Header("子彈速度"), Range(0, 5000)]
    public int speedBullet = 800;
    [Header("開槍音效")]
    public AudioClip soundFire;
    public int lives = 3;
    [Header("檢查地面位移")]
    public Vector2 offset;
    [Header("檢查地面半徑")]
    public float radius = 0.3f;

    public int score;
    public AudioClip bulletAU;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private gameManager gm;

    // 事件：喚醒 - 在 Start 之前執行一次
    // 剛體 = 取得元件<剛體元件>()；
    // 抓到角色身上的剛體元件存放到 rig 欄位內
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        // 透過<類型>取得物件
        // 僅限於此<類型>在場景上只有一個
        gm = FindObjectOfType<gameManager>();
    }
    //重復執行
    private void Update()
    {
        Move();
        Fire();
        Jump();
    }
    private void Move()
    {
        // 水平浮點數 = 輸入 的 取得軸向("水平") - 左右AD
        float L = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(L * speed, rig.velocity.y);
        // 動畫 的 設定布林值(參數名稱，水平 不等於 零時勾選)
        // != 不等於，傳回布林值
        // KeyCode 列舉(下拉式選單) - 所有輸入的項目 滑鼠、鍵盤、搖桿
        ani.SetBool("run Bool", L != 0);
        if (Input.GetKeyDown(KeyCode.D))
        {
            // transform 此物件的變形元件
            // eulerAngles 歐拉角度 0 - 180 - 270 - 360...
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        // KeyCode 列舉(下拉式選單) - 所有輸入的項目 滑鼠、鍵盤、搖桿
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void Jump()
    {
        // 如果 角色在地面上 並且 按下空白鍵 才能跳躍
        if (floor && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(transform.up * jump);
        }
        // 如果 物理 圓形範圍 碰到 圖層 8 的地板物件
        else if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + offset, radius, 1 << 8))
        {
            floor = true;
        }
        // 沒有碰到地板物件
        else
        {
            floor = false;                     // 不在地面上了
        }
    }
    private void AddForce(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {
        // 按下左鍵之後
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // 音源 的 播放一次音效(音效，隨機大小聲)
            //aud.PlayOneShot(soundFire, Random.Range(0.8f, 1.5f));
            // 生成 子彈在槍口
            // 生成(物件，座標，角度)
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            // 讓子彈飛
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * speedBullet + transform.up * 100);
        }
    }
    /// <summary>
    /// 死亡功能
    /// </summary>
    /// <param name="obj">碰到物件的名稱</param>
    private void Dead(string obj)
    {

        // 如果 物件名稱 等於 死亡區域
        if (obj == "死亡區域" || obj == "敵人子彈")
        {
            if (ani.GetBool("death Bool")) return;
            //this.enabled = false;
            enabled = false;                    // 此腳本 關閉
            ani.SetBool("death Bool", true);

            // 延遲呼叫("方法名稱"，延遲時間)
            Invoke("Replay", 2.5f);
            // 呼叫 GM 處理玩家死亡
            gm.playerDead();
        }
    }
    /// <summary>
    /// 重新遊戲
    /// </summary>
    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // OCE 碰撞時執行一次的事件
    // collision 碰到物件的資訊
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.tag);
    }
    // 繪製圖示：僅顯示魚場景面板
    private void OnDrawGizmos()
    {
        // 圖示 顏色
        Gizmos.color = Color.red;
        // 圖示 繪製球體(中心點，半徑)
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y) + offset, radius);
    }
    
        
}

