using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tmp2_Pivot : MonoBehaviour
{
    public GameObject playerController;
    public GameObject centerEye;
    bool isUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (centerEye.transform.eulerAngles.x <= 310 && centerEye.transform.eulerAngles.x >= 270 && isUp == false)
        {
            isUp = true;
            this.transform.position = playerController.transform.position;
        }
        else if ((centerEye.transform.eulerAngles.x >= 310 || centerEye.transform.eulerAngles.x <= 270) && isUp == true)
        {
            isUp = false;
            this.transform.position = centerEye.transform.position;
        }
    }
}
