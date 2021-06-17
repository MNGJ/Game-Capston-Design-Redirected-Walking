using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot_Center : MonoBehaviour
{
    public GameObject centerEye;
    public GameObject trackingSpace;
    public GameObject playerController;
    bool isUp;

    public static float player_local_position_x;
    public static float player_local_position_z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (centerEye.transform.eulerAngles.x <= 310 && centerEye.transform.eulerAngles.x >= 270 && isUp == false)
        {
            player_local_position_x = centerEye.transform.localPosition.x;
            player_local_position_z = centerEye.transform.localPosition.z;
            this.transform.position = centerEye.transform.position;
            isUp = true;
            centerEye.transform.parent = this.transform;
            playerController.transform.parent = this.transform;
        }
        else if ((centerEye.transform.eulerAngles.x >= 310 || centerEye.transform.eulerAngles.x <= 270) && isUp == true)
        {
            isUp = false;
            playerController.transform.parent = null;
            centerEye.transform.parent = trackingSpace.transform;
            //Debug.Log("DDDDDDDDDDDDD");
            //this.transform.position = centerEye.transform.position;
        }
        else
        {
            //this.transform.position = centerEye.transform.position;
        }
    }
}
