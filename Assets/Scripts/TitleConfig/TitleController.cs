using UnityEngine;

public class TitleController : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel = default;
    [SerializeField] private GameObject configPanel = default;

    void Start()
    {

    }

    void onStartGame()
    {

    }

    void onLoadGame()
    {

    }

    void onConfigOpen()
    {
        configPanel.SetActive(true);
    }

    void onConfigClose()
    {
        configPanel.SetActive(false);
    }
}
