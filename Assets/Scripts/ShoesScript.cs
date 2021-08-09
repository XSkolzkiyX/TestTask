using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesScript : MonoBehaviour
{
    public int LegID;
    GameObject Leg;
    void Update()
    {
        switch (LegID)
        {
            case 1:
                Leg = GameObject.Find("TT L Foot");
                break;
            case 2:
                Leg = GameObject.Find("TT R Foot");
                break;
            default:
                Debug.Log("Invalid ID");
                break;
        }
        if (Leg != null)
        {
            //transform.rotation = Leg.transform.rotation;
            var rot = transform.rotation;
            rot.x = Leg.transform.rotation.x + 90;
            rot.y = Leg.transform.rotation.y;
            rot.z = Leg.transform.rotation.z;
            transform.rotation = rot;
            transform.position = new Vector3(Leg.transform.position.x - 0.4f, Leg.transform.position.y, Leg.transform.position.z);
            //transform.position = Leg.transform.position;
        }
    }
}
