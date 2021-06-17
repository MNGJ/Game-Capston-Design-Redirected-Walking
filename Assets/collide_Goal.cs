using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_Goal : MonoBehaviour
{
    public GameObject goalText;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            goalText.SetActive(true);
        }
    }
}
