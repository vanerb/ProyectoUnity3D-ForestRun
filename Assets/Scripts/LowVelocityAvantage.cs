using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowVelocityAvantage : MonoBehaviour
{
    public static bool isLowVelocityActive = false;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Vector3.up, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            isLowVelocityActive = true;
            Destroy(this.gameObject);
        }
    }
}
