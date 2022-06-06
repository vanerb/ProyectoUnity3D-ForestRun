using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoins : MonoBehaviour
{
    public static bool isDoubleCoins = false;
   
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
            isDoubleCoins = true;
            Destroy(this.gameObject);
        }
    }
}
