using UnityEngine;
using UnityEngine.UI;

using Configs;

public class ConfigBase : MonoBehaviour
{
    /// <summary>
    /// ラベルメッセージ
    /// </summary>
    [SerializeField] protected string label = default;

    /// <summary>
    /// ラベルメッセージ（表示用）
    /// </summary>
    [SerializeField] protected Text labelText = default;

    /// <summary>
    /// 入力値
    /// </summary>
    [SerializeField] protected int inputValue = default;

    /// <summary>
    /// データ名
    /// </summary>
    [SerializeField] protected ConfigStatus.CONFIG_INDEX inputKey = default;

    /// <summary>
    /// 初期化
    /// </summary>
    protected void Start()
    {
        labelText.text = label;
    }

    /// <summary>
    /// オブジェクト活性化
    /// </summary>
    protected virtual void OnEnable()
    {
        string key = ConfigStatus.ConfigKeys[(int)inputKey];
        inputValue = PlayerPrefs.GetInt(key, 1);
    }

    /// <summary>
    /// 入力データの取得
    /// </summary>
    /// <returns>入力データ</returns> 
    public int GetValue()
    {
        return inputValue;
    }

    /// <summary>
    /// 入力データの名前取得
    /// </summary>
    /// <returns></returns>
    public string GetKey()
    {
        return ConfigStatus.ConfigKeys[(int)inputKey];
    }
}
