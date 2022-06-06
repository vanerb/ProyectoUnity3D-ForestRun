using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // components
    Rigidbody rigid;

    [Range(-1, 1)] [SerializeField] int position;

    Vector3 destiny;

    bool toRight;
    bool toLeft;

    bool inFloor;

    [Header("SETUP")]

    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpForce = 5f;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (transform.position == destiny)
        {

            if ((Input.GetButtonDown("Right")) && (position < 1))
            {
                destiny.x = transform.position.x + 1;
                position++;
            }

            if ((Input.GetButtonDown("Left")) && (position > -1))
            {
                destiny.x = transform.position.x - 1;
                position--;
            }

            
        }


        Vector3 xDestiny = new Vector3(destiny.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, xDestiny, moveSpeed * Time.deltaTime);

        //salto
        if ((Input.GetButtonDown("Up")) && (inFloor))
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if ((Input.GetButtonDown("Up")) && (inFloor))
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionStay()
    {
        inFloor = true;
    }

    private void OnCollisionExit()
    {
        inFloor = false;
    }
}
