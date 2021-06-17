using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 2500.0f);
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            UIManager.score++;
            Destroy(gameObject);
        }
    }

    IEnumerator Die()
    {

        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
