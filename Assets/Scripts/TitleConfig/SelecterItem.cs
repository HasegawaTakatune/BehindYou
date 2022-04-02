using UnityEngine;
using UnityEngine.UI;

public class SelecterItem : MonoBehaviour
{
    [SerializeField] private string label = default;
    [SerializeField] private Text labelText = default;
    [SerializeField] private Dropdown dropdown = default;

    public int selected = default;

    public void onSelectorChanged()
    {
        selected = dropdown.value;
    }

    private void Start()
    {
        labelText.text = label;
    }
}
