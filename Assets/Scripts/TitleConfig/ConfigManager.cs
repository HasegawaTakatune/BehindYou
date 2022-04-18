using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Configs;

public class ConfigManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static ConfigManager instance;

    /// <summary>
    /// 解像度
    /// </summary>
    public static int resolution;

    /// <summary>
    /// BGM
    /// </summary>
    public static int bgm;

    /// <summary>
    /// SE
    /// </summary>
    public static int se;

    /// <summary>
    /// 声音
    /// </summary>
    public static int voice;

    /// <summary>
    /// 文字速度
    /// </summary>
    public static int textSpeed;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            initConfig();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 設定の初期化
    /// </summary>
    private void initConfig()
    {
        try
        {
            resolution = PlayerPrefs.GetInt(ConfigStatus.RESOLUTION, 1);
            bgm = PlayerPrefs.GetInt(ConfigStatus.BGM, 1);
            se = PlayerPrefs.GetInt(ConfigStatus.SE, 1);
            voice = PlayerPrefs.GetInt(ConfigStatus.VOICE, 1);
            textSpeed = PlayerPrefs.GetInt(ConfigStatus.TEXT_SPEED, 1);
        }
        catch (Exception e)
        {
            Debug.LogError("設定データの取得に失敗しました。" + e);
        }
    }
}
