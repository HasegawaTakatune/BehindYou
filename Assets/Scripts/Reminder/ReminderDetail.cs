using UnityEngine;
using UnityEngine.UI;

public class ReminderDetail : MonoBehaviour
{
    [SerializeField] private Text date = default;
    [SerializeField] private Text message = default;

    public void Open(string date, string message)
    {
        this.date.text = date;
        this.message.text = message;
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
