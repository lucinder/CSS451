using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderWithEcho : MonoBehaviour
{

	public Text TheEcho;
	public Slider TheSlider;
	
	// Use this for initialization
	private void Start ()
	{
		TheEcho = this.transform.Find("Echo").GetComponent<Text>();
		TheSlider = this.transform.Find("Slider").GetComponent<Slider>();
		UpdateValue(TheSlider.value);
		TheSlider.onValueChanged.AddListener(UpdateValue);
	}

	private void UpdateValue(float value)
	{
		TheEcho.text = value.ToString(CultureInfo.CurrentCulture);
	}

    public void InitSliderControl(float minValue, float maxValue, float currentValue)
    {
        TheSlider.minValue = minValue;
        TheSlider.maxValue = maxValue;
        TheSlider.value = currentValue;
    }

    public void AddValueChanged(UnityAction<float> callback)
    {
        TheSlider.onValueChanged.AddListener(callback);
    }

    public void RemoveListener(UnityAction<float> callback)
    {
        TheSlider.onValueChanged.RemoveListener(callback);
    }
}
