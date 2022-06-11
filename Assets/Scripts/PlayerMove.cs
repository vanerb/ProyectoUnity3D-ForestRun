using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerMove : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public float jumpForce;
    public float Gravity = -20;

    public static int numberOfCoins;
    public Text coinstext;
    public static int contador = 0;
    public Text cont;
    private int reset;


    public Animator animator;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public AudioSource musicaFondo;
    public float volume = 1;
    public AudioSource correr;
    public AudioSource salto;
    public AudioSource desliza;
    public AudioSource daño;
    public AudioSource clickBoton;

  


    private bool isSliding = false;

    public float slideDuration = 1.5f;

    


    //AVANTAGE VELOCITY

    public float durationLowVelocity;
    private float time;
   

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        numberOfCoins = 0;
        musicaFondo.Play();

        time = durationLowVelocity;
        
    }

    public void Reset()
    {
        contador = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (LowVelocityAvantage.isLowVelocityActive == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                LowVelocityAvantage.isLowVelocityActive = false;
                time = durationLowVelocity;
            }
        }

        contador++;
        cont.text = "Km: " + contador;

       

        if(LowVelocityAvantage.isLowVelocityActive == true)
        {
            if (forwardSpeed < maxSpeed)
            {
                if(forwardSpeed > 2)
                {
                    forwardSpeed -= 0.5f * Time.deltaTime;
                }
                else
                {
                    forwardSpeed += 0.1f * Time.deltaTime;
                }
                
            }
        }
        else if (LowVelocityAvantage.isLowVelocityActive == false)
        {
            if (forwardSpeed < maxSpeed)
            {
                forwardSpeed += 0.1f * Time.deltaTime;
            }
                
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
       // animator.SetBool("isGrounded", isGrounded);


        if (controller.isGrounded)
        {

            animator.SetBool("isGrounded", true);
            

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isSliding == false)
                {
                    Jump();
                    //isSliding = false;

                }
            }
            else if (ControlesMoviles.swipeUp)
            {
                if (isSliding == false)
                {
                    Jump();
                    //isSliding = false;
                    
                }
               
            }
        }
        else
        {
            
            //animator.SetBool("isGrounded", true);

            direction.y += Gravity * Time.deltaTime;

           
        }


        if (ControlesMoviles.swipeDown && !isSliding)
        {
           
            StartCoroutine(Slide());
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
           
            StartCoroutine(Slide());
        }

        direction.z = forwardSpeed;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        else if (ControlesMoviles.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        else if (ControlesMoviles.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        coinstext.text = "Coins: " + numberOfCoins;
        
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);
        //controller.center = controller.center;

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
            
       

        controller.Move(direction * Time.deltaTime);



    }


    private void FixedUpdate()
    {
        
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        animator.SetBool("isGrounded", false);
        salto.Play();
        correr.volume = 0;
        isSliding = false;

        direction.y = jumpForce;
        

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        

        if (hit.transform.tag == "Obstacle")
        {
            
                Reset();
                cont.GetComponent<Text>().enabled = false;
                coinstext.GetComponent<Text>().enabled = false;
                daño.Play();
                animator.Play("Standing React Death Backward");
                correr.Stop();
                musicaFondo.Stop();
                this.enabled = false;
                Invoke("Example", 2f);
                PlayerPrefs.SetInt("coins", numberOfCoins);

        }

     
    }

   
    private void anim()
    {
        animator.Play("VuelveIntentar");
    }

    private void Example()
    {
        Invoke("anim", 2f);
        Time.timeScale = 1;
        Damage.gameOver = true;
        


    }

    



    private IEnumerator Slide()
    {
        
        desliza.Play();
        correr.volume = 0;
        isSliding = true;
        animator.SetBool("isSliding", true);
        yield return new WaitForSeconds(0.25f / Time.timeScale);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1.3f;

        yield return new WaitForSeconds((slideDuration - 0.25f) / Time.timeScale);

        animator.SetBool("isSliding", false);

        controller.center = Vector3.zero;
        controller.height = 2;
        
        isSliding = false;
        
    }


   

}
