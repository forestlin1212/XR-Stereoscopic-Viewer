using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class IPD_Adjustment : MonoBehaviour
{
    public Slider targetSlider;
    public TextMeshProUGUI valueText;  
    public Transform leftPlane, rightPlane;

    private void Start()
    {
        // 确认引用到Slider，并且添加监听事件
        if (targetSlider)
        {
            targetSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
        UpdateTextValue(targetSlider.value);
    }
    
    private void OnSliderValueChanged(float IPDvalue)
    {
        leftPlane.localPosition = new Vector3(-IPDvalue / 2, 0.0f, 0.0f);
        rightPlane.localPosition = new Vector3(IPDvalue / 2, 0.0f, 0.0f);

        UpdateTextValue(IPDvalue * 100);
    }

    private void UpdateTextValue(float value)
    {
        if (valueText) // 检查是否有TMP文本组件被引用
        {
            valueText.text = "IPD: " + value.ToString("0"); // 这里将数值保留两位小数，你可以按需修改
        }
    }
}
