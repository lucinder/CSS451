using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectControlUIScript : MonoBehaviour {

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
        XSlider.InitSliderControl(-180, 180, 0);
        YSlider.InitSliderControl(-180, 180, 0);
        ZSlider.InitSliderControl(-180, 180, 0);

        //XSlider.onValueChanged.AddListener()

        XSlider.AddValueChanged((float value) => 
        {
            Vector3 rot = selectedObject.rotation.eulerAngles;
            rot.x = value;
            selectedObject.rotation = Quaternion.Euler(rot);
        });
        YSlider.AddValueChanged((float value) =>
        {
            Vector3 rot = selectedObject.rotation.eulerAngles;
            rot.y = value;
            selectedObject.rotation = Quaternion.Euler(rot);
        });

        ZSlider.AddValueChanged((float value) =>
        {
            Vector3 rot = selectedObject.rotation.eulerAngles;
            rot.z = value;
            selectedObject.rotation = Quaternion.Euler(rot);
        });
    }
}
