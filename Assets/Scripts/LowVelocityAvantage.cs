using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowVelocityAvantage : MonoBehaviour
{
    public static bool isLowVelocityActive = false;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
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
