using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{

    public GameObject bullet; //발사할 총알
    public Transform rightFirePos; //발사되는 위치
    public Transform leftFirePos;
    public ParticleSystem flashL;
    public ParticleSystem flashR;
    public Camera mainCamera;
    public Camera subCamera;
    bool ismain;

    void Start()
    {
        ismain = true;
    }

    // Update is called once per frame
    void Update()
    {
        BulletFire();
    }

    void BulletFire()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Instantiate(bullet, rightFirePos.position, rightFirePos.rotation);
            flashR.Play();
        }

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Instantiate(bullet, leftFirePos.position, leftFirePos.rotation);
            flashL.Play();
        }

        if(OVRInput.GetDown(OVRInput.Button.Four))
        {
            if (ismain == true)
            {
                ismain = false;
                mainCamera.enabled = false;
                subCamera.enabled = true;
            }
            else if (ismain == false)
            {
                ismain = true;
                mainCamera.enabled = true;
                subCamera.enabled = false;
            }
        }
    }
}
