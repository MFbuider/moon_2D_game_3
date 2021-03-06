﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [Header("生命物件陣列")]
    public GameObject[] lives;
    [Header("分數文字介面")]
    public Text textScore;
    [Header("結束畫面")]
    public GameObject final;
    // 一般欄位 重新載入場景 會還原為預設值
    // 靜態欄位 重新載入場景 不會還原為預設值
    public static int live = 3;
    public int score;
    private void Awake()
    {
        SetCollision();
        setlive();
    }

    private void Start()
    {
        setlive();
    }
    private void Update()
    {
        Baketomenu();
        QuitGame();
    }

    /// <summary>
    /// 玩家死亡
    /// </summary>
    public void playerDead()
    {
        live--;
        setlive();
        if (live == 0) final.SetActive(true);
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
    for (int i = 0; i < 3; i++)
        {
            if (i >= live) lives[i].SetActive(false);
        }
    }
    /// <summary>
    ///  更新生命介面
    /// </summary>
    private void SetLive()
    {
        // 陣列欄位[編號] 的 方法()
        //lives[0].SetActive(false);

        //for (int i = 1; i < 100; i++)
        //{
        //    print("迴圈：" + i);
        //}
        for (int i = 0; i < lives.Length; i++)
        {
            if (i >= live) lives[i].SetActive(false);
        }
    }
    private void Baketomenu()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("選單");
    }
    private void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
    /// <summary>
    /// 設定碰撞：所有圖層的碰撞
    /// </summary>
    private void SetCollision()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("enemy"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("player"), LayerMask.NameToLayer("子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("子彈"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人子彈"), LayerMask.NameToLayer("敵人子彈"));
    }
}
