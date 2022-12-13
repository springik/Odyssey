using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatParent : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        Debug.Log(text);
        btn = GetComponentInChildren<Button>();
        Debug.Log(btn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
