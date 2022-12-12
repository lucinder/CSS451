using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSpin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = gameObject.transform.rotation.eulerAngles;
        rot.y -= Time.deltaTime*10f; // rotate pieces 90 degrees counterclockwise
        gameObject.transform.rotation = Quaternion.Euler(rot); 
    }
}
