using UnityEngine;

public class TitleController : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel = default;
    [SerializeField] private GameObject configPanel = default;

    public void onStartGame()
    {
        Debug.Log("Game start");
    }

    public void onLoadGame()
    {
        Debug.Log("Game load");
    }

    public void onConfigOpen()
    {
        configPanel.SetActive(true);
        titlePanel.SetActive(false);
    }

    public void onConfigClose()
    {
        titlePanel.SetActive(true);
        configPanel.SetActive(false);
    }

    public void onExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
