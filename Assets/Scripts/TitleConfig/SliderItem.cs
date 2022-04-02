using UnityEngine;
using UnityEngine.UI;

public class SliderItem : MonoBehaviour
{
    [SerializeField] private string label = default;
    [SerializeField] private Text labelText = default;
    [SerializeField] private Slider inputSlider = default;
    [SerializeField] private InputField inputText = default;

    public int volume = default;

    public void onSliderChenged()
    {
        inputText.text = inputSlider.value.ToString();
        volume = (int)inputSlider.value;
    }

    public void onInputChenged()
    {
        int value = int.Parse(inputText.text);
        inputSlider.value = value;
        volume = value;
    }

    private void Start()
    {
        labelText.text = label;
    }
}
