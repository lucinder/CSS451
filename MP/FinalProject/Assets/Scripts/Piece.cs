using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Piece : MonoBehaviour
{
    float vX, vY, vZ;
    public Transform BaseCollider, RobotHand1, RobotHand2, RobotArm, AbyssCollider;
    System.Random r = new System.Random();
    void Start(){
        vX = 0f; vY = 0f; vZ = 0f;
        BaseCollider = gameObject.GetComponent<Selectable>().GetBoard();
        LoadBits();
    }
    void LoadBits(){
        Transform cur = gameObject.transform;
        while(!cur.GetComponent<MainWorldController>()){
            cur = cur.parent;
        }
        AbyssCollider = cur.Find("TheAbyss");
        cur = cur.Find("RobotArmBase");
        cur = cur.Find("LowerJoint");
        cur = cur.Find("BackArm");
        cur = cur.Find("UpperJoint");
        RobotArm = cur.Find("ForeArm");
        cur = cur.Find("ForeArm");
        RobotHand1 = cur.Find("Finger1");
        RobotHand2 = cur.Find("Finger2");
        
    }
    void Update(){
        vX /= 2f;
        if(!CollidingWith(BaseCollider)) vY -= 9.8f;
        vZ /= 2f;
        if(CollidingWith(RobotHand1) || CollidingWith(RobotHand2) || CollidingWith(RobotArm)){
            vX += (float)r.Next(20);
            vY += (float)r.Next(20);
        }
        if(CollidingWith(AbyssCollider)){ Destroy(gameObject); }
        float pX = gameObject.transform.localPosition.x + vX;
        float pY = gameObject.transform.localPosition.y + vY;
        float pZ = gameObject.transform.localPosition.z + vZ;
        gameObject.transform.localPosition = new Vector3(pX, pY, pZ);
    }

    bool CollidingWith(Transform Collider){
        return (Vector3.Dot(gameObject.transform.position, Collider.up) > Vector3.Dot(Collider.up, Collider.position)) && (Mathf.Abs((Collider.position - gameObject.transform.position).magnitude) < Collider.localScale.x / 2f);
    }
}
