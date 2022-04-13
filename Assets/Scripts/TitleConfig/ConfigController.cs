using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [SerializeField] Dictionary<string, ConfigBase> configs = new Dictionary<string, ConfigBase>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SaveConfig()
    {
    }
}
