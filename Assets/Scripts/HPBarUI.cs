using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = StatManager.getStatOfType("HP").realVal;
        StatManager.Instance.statsChanged += OnStatsChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnStatsChanged(float value)
    {
        slider.maxValue = StatManager.getStatOfType("HP").realVal;
        slider.value = value;
    }
}
