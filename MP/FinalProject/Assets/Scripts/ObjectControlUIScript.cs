using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectControlUIScript : MonoBehaviour {

    public Toggle T, S, R;
    public SliderWithEcho XSlider, YSlider, ZSlider;
    public Transform selectedObject;

	// Use this for initialization
	void Start () {

        Invoke("Init", .1f);
    }

    public void SetSelectedObject(Transform newObject){
        selectedObject = newObject;
    }

    private void Init()
    {
        T.onValueChanged.AddListener((bool isChecked) => {

            if (isChecked)
            {
                XSlider.InitSliderControl(-4, 4, 0);
                YSlider.InitSliderControl(-4, 4, 0);
                ZSlider.InitSliderControl(0, 0, 0);
            }
        });
        S.onValueChanged.AddListener((bool isChecked) => {
            if (isChecked)
            {
                XSlider.InitSliderControl(.1f, 10, 1);
                YSlider.InitSliderControl(.1f, 10, 1);
                ZSlider.InitSliderControl(1, 1, 1);
            }
        });
        R.onValueChanged.AddListener((bool isChecked) => {
            if (isChecked)
            {
                XSlider.InitSliderControl(0, 0, 0);
                YSlider.InitSliderControl(0, 0, 0);
                ZSlider.InitSliderControl(-180, 180, 0);
            }
        });

        //XSlider.onValueChanged.AddListener()

        XSlider.AddValueChanged((float value) => 
        {
            if (T.isOn)
            {
                Vector3 pos = selectedObject.localPosition;
                selectedObject.localPosition = new Vector3(value,pos.y,pos.z);
            }
            else if (S.isOn)
            {
                Vector3 scale = selectedObject.localScale;
                selectedObject.localScale = new Vector3(value,scale.y,scale.z);
            }
            else if(R.isOn)
            {
                Vector3 rot = selectedObject.rotation.eulerAngles;
                rot.x = value;
                selectedObject.rotation = Quaternion.Euler(rot);
            }
        });
        YSlider.AddValueChanged((float value) =>
        {
            if (T.isOn)
            {
                Vector3 pos = selectedObject.localPosition;
                selectedObject.localPosition = new Vector3(pos.x,value,pos.z);
            }
            else if (S.isOn)
            {
                Vector3 scale = selectedObject.localScale;
                selectedObject.localScale = new Vector3(scale.x,value,scale.z);
            }
            else if(R.isOn)
            {
                Vector3 rot = selectedObject.rotation.eulerAngles;
                rot.y = value;
                selectedObject.rotation = Quaternion.Euler(rot);
            }

        });

        ZSlider.AddValueChanged((float value) =>
        {
            if (T.isOn)
            {
                Vector3 pos = selectedObject.localPosition;
                selectedObject.localPosition = new Vector3(pos.x,pos.y,value);
            }
            else if (S.isOn)
            {
                Vector3 scale = selectedObject.localScale;
                selectedObject.localScale = new Vector3(scale.x,scale.y,value);
            }
            else if(R.isOn)
            {
                Vector3 rot = selectedObject.rotation.eulerAngles;
                rot.z = value;
                selectedObject.rotation = Quaternion.Euler(rot);
            }
        });

        T.isOn = true;
        R.isOn = false;
        S.isOn = false;
    }
}
