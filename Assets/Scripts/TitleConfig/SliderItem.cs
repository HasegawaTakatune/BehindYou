using UnityEngine;
using UnityEngine.UI;

public class SliderItem : ConfigBase
{
    /// <summary>
    /// スライダー
    /// </summary>
    [SerializeField] private Slider inputSlider = default;

    /// <summary>
    /// テキスト入力
    /// </summary>
    [SerializeField] private InputField inputText = default;

    /// <summary>
    /// スライダー入力イベント
    /// </summary>
    public void onSliderChenged()
    {
        inputText.text = inputSlider.value.ToString();
        inputValue = (int)inputSlider.value;
    }

    /// <summary>
    /// テキスト入力イベント
    /// </summary>
    public void onInputChenged()
    {
        int value = int.Parse(inputText.text);
        inputSlider.value = value;
        inputValue = value;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private new void Start()
    {
        base.Start();
    }

    /// <summary>
    /// 活性化イベント
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        inputSlider.value = inputValue;
        inputText.text = inputValue.ToString();
    }
}
