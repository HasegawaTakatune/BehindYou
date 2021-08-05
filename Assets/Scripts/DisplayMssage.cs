using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMssage : MonoBehaviour
{
    /// <summary>
    /// 背景画像ディレクトリ
    /// </summary>
    private const string DIRECTORY_BACKGROUND_IMAGE = "Images/Background/";

    /// <summary>
    /// キャラクタ画像ディレクトリ
    /// </summary>
    private const string DIRECTORY_CHARACTER_IMAGE = "Images/Character/";

    /// <summary>
    /// プレファブディレクトリ
    /// </summary>
    private const string DIRECTORY_PREFABS = "Prefabs/";

    private const string DIRECTORY_BGM = "BGM/";

    /// <summary>
    /// 背景画像インスタンス
    /// </summary>
    [SerializeField]
    private Image backgroundImage = default;

    /// <summary>
    /// キャラクターパネル
    /// </summary>
    [SerializeField]
    private GameObject characterPanel = default;

    /// <summary>
    /// 名前ウィンドウ
    /// </summary>
    [SerializeField]
    private Text nameWindow = default;

    /// <summary>
    /// 名前パネル
    /// </summary>
    [SerializeField]
    private GameObject namePanel = default;

    /// <summary>
    /// メッセージウィンドウ
    /// </summary>
    [SerializeField]
    private Text messageWindow = default;

    /// <summary>
    /// メッセージパネル
    /// </summary>
    [SerializeField]
    private GameObject messagePanel = default;

    /// <summary>
    /// コンテンツインデックス
    /// </summary>
    private int index = 0;

    /// <summary>
    /// 選択肢パネル
    /// </summary>
    [SerializeField]
    private GameObject choicesPanel = default;

    [SerializeField]
    private AudioSource bgmAudio = default;

    /// <summary>
    /// 選択肢リスト
    /// </summary>
    /// <typeparam name="Button">ボタン</typeparam>
    /// <returns>ボタンリスト</returns>
    private List<Button> choicesButtons = new List<Button>();

    /// <summary>
    /// キャラクター画像を保存する
    /// </summary>
    /// <typeparam name="Image">画像</typeparam>
    /// <returns>画像リスト</returns>
    private List<Image> characterImages = new List<Image>();

    /// <summary>
    /// 章の保存
    /// </summary>
    private Chapter chapter = default;

    /// <summary>
    /// シナリオの保存
    /// </summary>
    private Scenario scenario = default;

    /// <summary>
    /// 文字表示速度
    /// </summary>
    [SerializeField]
    private float captionSpeed = 0.2f;

    /// <summary>
    /// 文字をキュー保存
    /// </summary>
    private Queue<char> charQueue;

    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/HelloScenario").ToString();
        chapter = JsonUtility.FromJson<Chapter>(json);
        scenario = chapter.scenario[0];

        SetContent();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickMouseLeftButton();
        }
    }

    /// <summary>
    /// マウス右クリックイベント
    /// </summary>
    private void OnClickMouseLeftButton()
    {
        if (0 < charQueue.Count) OutputAllChar();
        else
        {
            if (0 < choicesButtons.Count) return;
            index++;
            SetContent();
        }
    }

    /// <summary>
    /// コンテンツ設定
    /// </summary>
    private void SetContent()
    {
        messageWindow.text = "";
        nameWindow.text = "";

        Content content = scenario.content[index];

        // 名前表示
        if (content.IsSetCharacterName())
        {
            nameWindow.text = content.characterName;
            namePanel.SetActive(true);
        }
        else
        {
            namePanel.SetActive(false);
        }

        // メッセージ表示
        if (content.IsSetMessage())
        {
            charQueue = SeparateString(content.message);

            // 文字表示のテスト
            StartCoroutine(ShowMessage(captionSpeed));
        }

        // 選択肢表示
        if (content.IsSetChoices())
        {
            SetChoices(content);
        }

        // キャラクタ表示
        if (content.IsSetCharacter())
        {
            for (int i = 0; i < content.characteres.Length; i++)
            {
                SetCharacter(content.characteres[i]);
            }
        }

        if (content.IsSetBackground())
        {
            SetBackground(content.background);
        }

        if(content.IsSetBGM())
        {
            SetBGM(content.BGM);
        }
    }

    /// <summary>
    /// キャラクター設定
    /// </summary>
    /// <param name="character">キャラクターのパラメーター</param>
    private void SetCharacter(Character character)
    {
        Image image = characterImages.Find(n => n.name == character.name);

        if (image == null)
        {
            image = Instantiate(Resources.Load<Image>(DIRECTORY_PREFABS + "Character"), characterPanel.transform);
            image.name = character.name;
            characterImages.Add(image);
        }

        Sprite sprite = Instantiate(Resources.Load<Sprite>(DIRECTORY_CHARACTER_IMAGE + character.image));
        image.sprite = sprite;

        if (character.IsSetPosition())
        {
            image.GetComponent<RectTransform>().anchoredPosition = String2Vector3(character.position);
        }

        if (character.IsSetRotate())
        {
            image.GetComponent<RectTransform>().eulerAngles = String2Vector3(character.rotate);
        }

        if (character.IsSetSize())
        {
            image.GetComponent<RectTransform>().sizeDelta = String2Vector3(character.size);
        }

        if (character.IsSetColor())
        {
            image.color = String2Color(character.color);
        }

        if (character.IsDelete())
        {
            characterImages.Remove(image);
            Destroy(image.gameObject);
        }
    }

    /// <summary>
    /// 背景画像の設定
    /// </summary>
    /// <param name="fileName">背景画像名</param>
    private void SetBackground(string fileName)
    {
        Sprite sprite = Instantiate(Resources.Load<Sprite>(DIRECTORY_BACKGROUND_IMAGE + fileName));
        backgroundImage.sprite = sprite;
    }

    /// <summary>
    /// 選択肢設定
    /// </summary>
    /// <param name="content">コンテンツ</param>
    private void SetChoices(Content content)
    {
        choicesPanel.SetActive(true);
        Choices[] choices = content.choices;

        foreach (Choices choice in choices)
        {
            Button button = Instantiate(Resources.Load<Button>(DIRECTORY_PREFABS + "ChoiceButton"), choicesPanel.transform);
            Text text = button.GetComponentInChildren<Text>();
            text.text = choice.name;
            button.name = choice.name;
            button.onClick.AddListener(() => OnClickChoicesButton(choice.scenario));
            choicesButtons.Add(button);
        }
    }

    private void SetBGM(Audio bgm)
    {
        if (bgm.IsSetAudio())
        {
            Debug.Log(bgm.audio);
            AudioClip audio = Resources.Load<AudioClip>(DIRECTORY_BGM + bgm.audio);
            Debug.Log(audio);
            bgmAudio.clip = audio;
        }

        if (bgm.play) bgmAudio.Play();

        if (bgm.pause) bgmAudio.Pause();

        if (bgm.unpause) bgmAudio.UnPause();

        bgmAudio.pitch = bgm.pitch;
    }

    /// <summary>
    /// 選択肢ボタンクリックイベント
    /// </summary>
    /// <param name="jumpTo">遷移先の名前</param>
    private void OnClickChoicesButton(string jumpTo)
    {
        foreach (Button button in choicesButtons) Destroy(button.gameObject);
        choicesPanel.SetActive(false);
        choicesButtons.Clear();

        int idx = chapter.FindScenario2Index(jumpTo);

        if (idx == -1) idx = 0;
        index = 0;
        scenario = chapter.scenario[idx];

        SetContent();
    }

    /// <summary>
    /// 文字列をキューにして返す
    /// </summary>
    /// <param name="msg">文字列</param>
    /// <returns>文字列のキュー</returns>
    private Queue<char> SeparateString(string msg)
    {
        char[] chars = msg.ToCharArray();
        Queue<char> respQue = new Queue<char>();

        // 一つずつキューに加える
        foreach (char c in chars) respQue.Enqueue(c);
        return respQue;
    }

    /// <summary>
    /// メッセージ表示
    /// </summary>
    /// <param name="wait">待機時間</param>
    /// <returns>遅延</returns>
    private IEnumerator ShowMessage(float wait)
    {
        while (OutputChar()) yield return new WaitForSeconds(wait);
        yield break;
    }

    /// <summary>
    /// 1文字ずつ表示する
    /// </summary>
    private bool OutputChar()
    {
        if (charQueue.Count <= 0) return false;
        messageWindow.text += charQueue.Dequeue();
        return true;
    }

    /// <summary>
    /// 全文表示する
    /// </summary>
    private void OutputAllChar()
    {
        StopCoroutine(ShowMessage(captionSpeed));
        while (OutputChar()) ;
    }

    /// <summary>
    /// 文字列をVetor3へ変換する
    /// </summary>
    /// <param name="input">変換する文字列</param>
    /// <returns>Vector3</returns>
    private Vector3 String2Vector3(string input)
    {
        // 前後に丸括弧があれば削除し、カンマで分割
        string[] elements = input.Trim('(', ')').Split(',');
        Vector3 result = Vector3.zero;

        // ループ回数をelementsの数以下かつ3以下にする
        int length = Mathf.Min(elements.Length, 3);

        float value;
        for (int i = 0; i < length; i++)
        {
            value = 0;

            // 変換に失敗したときに例外が出る方が望ましければ、Parseを使うのがいいでしょう
            float.TryParse(elements[i], out value);
            result[i] = value;
        }

        return result;
    }

    /// <summary>
    /// 文字列をColorへ変換する
    /// </summary>
    /// <param name="input">変換する文字列</param>
    /// <returns>Color</returns>
    private Color String2Color(string input)
    {
        string[] elements = input.Trim('(', ')').Split(',');
        Color32 result = new Color32();

        int length = Mathf.Min(elements.Length, 4);

        byte value;
        for (int i = 0; i < length; i++)
        {
            value = 255;

            byte.TryParse(elements[i], out value);
            result[i] = value;
        }

        return result;
    }
}
