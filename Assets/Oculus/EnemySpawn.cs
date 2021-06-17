using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    private float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if(delay >= 5f)
        {
            Instantiate(Enemy, new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z), this.transform.rotation);
            delay = 0f;
        }
    }
}
