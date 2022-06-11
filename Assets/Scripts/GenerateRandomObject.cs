using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObject : MonoBehaviour
{
    public Transform[] posSpawn;
    private int randomPos;
    private int randomObject;
    public GameObject[] objects;
    public static int cant;
    private float time;
    public float timeToSpawn;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        time = timeToSpawn;

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            randomPos = Random.Range(0, posSpawn.Length);
            randomObject = Random.Range(0, objects.Length);
            Instantiate(objects[randomObject], new Vector3(posSpawn[randomPos].position.x, posSpawn[randomPos].position.y, posSpawn[randomPos].position.z), Quaternion.identity);
            time = timeToSpawn;
            

           
        }

       
       
        if (player.transform.position.x == -3.3f || player.transform.position.x == 3.3f)
        {
            posSpawn[0].transform.position = new Vector3(-3.3f, posSpawn[0].transform.position.y, posSpawn[0].transform.position.z);
            posSpawn[1].transform.position = new Vector3(0, posSpawn[1].transform.position.y, posSpawn[1].transform.position.z);
            posSpawn[2].transform.position = new Vector3(3.3f, posSpawn[2].transform.position.y, posSpawn[2].transform.position.z);
        }
        else
        {
            posSpawn[1].transform.position = new Vector3(-3.3f, posSpawn[1].transform.position.y, posSpawn[1].transform.position.z);
            posSpawn[2].transform.position = new Vector3(3.3f, posSpawn[2].transform.position.y, posSpawn[2].transform.position.z);
            posSpawn[0].transform.position = new Vector3(0, posSpawn[0].transform.position.y, posSpawn[0].transform.position.z);
        }


    }


    private void FixedUpdate()
    {
        
    }
}
    
   

