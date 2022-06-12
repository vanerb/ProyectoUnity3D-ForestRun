using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogidaMonedas : MonoBehaviour
{

    public AudioSource coinSon;
    public float durationDoubleCoins = 5;
    private float time;
    public bool isTime = false;
    public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        time = durationDoubleCoins;
        
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
        if (DoubleCoins.isDoubleCoins == true)
        {
            isTime = true;
            time -= Time.deltaTime;
            if (time <= 0)
            {
                isTime = false;
                DoubleCoins.isDoubleCoins = false;
                time = durationDoubleCoins;
            }
        }


       
       

}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isTime == true)
            {
                PlayerMove.numberOfCoins += 5;
                coinSon.Play();
                Destroy(gameObject);
                Debug.Log("Coins" + PlayerMove.numberOfCoins);
            }
            else
            {
                PlayerMove.numberOfCoins += 1;
                coinSon.Play();
                Destroy(gameObject);
                Debug.Log("Coins" + PlayerMove.numberOfCoins);
            }
                
            
        }
    }

   
}
