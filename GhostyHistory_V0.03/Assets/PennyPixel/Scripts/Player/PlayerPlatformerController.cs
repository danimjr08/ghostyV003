using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    /*
     * Mio
     */

    public Light2D AimLight;

    private Transform cameraTarget;

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
    }

    void Start()
    {
        cameraTarget = gameObject.transform.Find("CameraTarget");
        if (cameraTarget)
        {
            Debug.Log("Found camera target: " + cameraTarget.name);
        }
        
        if (AimLight)
        {
            AimLight.intensity = 0;
            
            Debug.Log("AimLight Exist!");
        }
        else
        {
            Debug.Log("Not found: AimLight");
        }

        
    }
    
   

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x > 0.1f)
        {
            cameraTarget.transform.Translate(2.25f *Time.deltaTime , 0 , 0 ); 
               // new Vector3(this.transform.position.x + 2.16f, cameraTarget.transform.position.y, cameraTarget.transform.position.z);

               if (cameraTarget.transform.localPosition.x > 2.16f)
               {
                   cameraTarget.transform.position = new Vector3( transform.position.x + 2.16f , cameraTarget.transform.position.y, cameraTarget.transform.position.z);
               }
               
               
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        if (move.x < -0.1f)
        {
            cameraTarget.transform.Translate(-2.25f *Time.deltaTime , 0 , 0 ); 
            //new Vector3(this.transform.position.x - 2.16f, cameraTarget.transform.position.y, cameraTarget.transform.position.z);
            
            if (cameraTarget.transform.localPosition.x < -2.16f)
            {
                cameraTarget.transform.position = new Vector3( transform.position.x - 2.16f , cameraTarget.transform.position.y, cameraTarget.transform.position.z);
                
                Debug.Log("Hola");
            }

            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
        /*
         * Mio
         */

        if (Input.GetButtonDown("Fire2"))
        {
            AimLight.intensity = 3.91f;
            
            Debug.Log("Fire 2 pressed");
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}