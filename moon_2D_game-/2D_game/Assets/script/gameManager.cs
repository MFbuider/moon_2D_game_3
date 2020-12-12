using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class gameManager : MonoBehaviour
{
    [Header("生命物件陣列")]
    public GameObject[] lives;
    [Header("分數文字介面")]
    public Text textScore;
    // 一般欄位 重新載入場景 會還原為預設值
    // 靜態欄位 重新載入場景 不會還原為預設值
    public static int live = 3;
    public static int score;
    private void Awake()
    {
        SetCollision();
        setlive();
        AddScore(0);
    }
    /// <summary>
    /// 玩家死亡
    /// </summary>
    public void playerDead()
    {
        live--;
        setlive();
    }
    /// <summary>
    /// 添加分數
    /// </summary>
    public void AddScore (int add)
    {
        score += add;
        textScore.text = "分數：" + score;
    }
    private void setlive()
    {
    for (int i = 1; i < 100; i++)
        {
            if (i >= live) lives[i].SetActive(false);
        }
    }
    /// <summary>
    /// 設定碰撞：所有圖層的碰撞
    /// </summary>
    private void SetCollision()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人"), LayerMask.NameToLayer("敵人"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家"), LayerMask.NameToLayer("玩家子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家子彈"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人子彈"), LayerMask.NameToLayer("敵人子彈"));
    }
}
