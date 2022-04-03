using UnityEngine;
using UnityEngine.UI;

public class SliderItem : MonoBehaviour
{
    /// <summary>
    /// 表示するラベル文字
    /// </summary>
    [SerializeField] private string label = default;

    /// <summary>
    /// 表示するラベルオブジェクト
    /// </summary>
    [SerializeField] private Text labelText = default;

    /// <summary>
    /// スライダー
    /// </summary>
    [SerializeField] private Slider inputSlider = default;
    /// <summary>
    /// テキスト入力
    /// </summary>
    [SerializeField] private InputField inputText = default;

    /// <summary>
    /// 入力値
    /// </summary>
    public int volume = default;

    /// <summary>
    /// スライダー入力イベント
    /// </summary>
    public void onSliderChenged()
    {
        inputText.text = inputSlider.value.ToString();
        volume = (int)inputSlider.value;
    }

    /// <summary>
    /// テキスト入力イベント
    /// </summary>
    public void onInputChenged()
    {
        int value = int.Parse(inputText.text);
        inputSlider.value = value;
        volume = value;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        labelText.text = label;
    }
}
