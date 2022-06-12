using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoins : MonoBehaviour
{
    public static bool isDoubleCoins = false;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused == true)
        {
            transform.Rotate(0 * Vector3.up, Space.World);
        }
        else
        {
            transform.Rotate(speed * Vector3.up, Space.World);
        }
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
