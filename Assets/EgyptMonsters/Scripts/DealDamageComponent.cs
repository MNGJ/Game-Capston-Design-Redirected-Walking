using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageComponent : MonoBehaviour {

    public GameObject hitFX;
    public GameObject dieParticle;
	void DealDamage() {
        transform.parent.GetComponent<DemoController>().DealDamage(this);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward*0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Collide");
            Destroy(gameObject);
            Instantiate(dieParticle, this.transform.position + new Vector3(0f, 1.8f, 0f), this.transform.rotation);
        }
    }

}
