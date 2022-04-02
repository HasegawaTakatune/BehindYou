using UnityEngine;
using UnityEngine.UI;

public class RadioItem : MonoBehaviour
{
    [SerializeField] private string label = default;
    [SerializeField] private Text labelText = default;
    [SerializeField] private Button[] radioButtons = default;
    public int clicked = default;

    public void onClickedRadio(int index)
    {
        Debug.Log(index);
        for (int i = 0; i < radioButtons.Length; i++)
            radioButtons[i].interactable = (i != index);

        clicked = index;
    }

    private void Start()
    {
        labelText.text = label;

        for (int i = 0; i < radioButtons.Length; i++)
            if (radioButtons[i].interactable == false) clicked = i;


    }
}
