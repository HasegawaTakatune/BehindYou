using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/HelloScenario").ToString();
        Scenario[] scenario = JsonUtility.FromJson<Scenario[]>(json);
        // Debug.Log(scenario);

        // Debug.Log("Key :" + scenario[0].name + "  Value :" + scenario[0].content[0].message);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
