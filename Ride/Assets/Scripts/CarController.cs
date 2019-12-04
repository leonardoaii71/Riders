using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    bool move = false;
    bool isGrounded = false;
	private float upsideDown = 0f;
    public Rigidbody2D rb;
    public float speed = 20f;
    public float rotationSpeed = 2f;
    public Vector3 acceleracion = new Vector3(5, 0, 0);
	float distanceTravelled = 0;
	Vector3 lastPosition;
    
    MR movimientoRectilineo;


    private void Start()
    {
		lastPosition = transform.position;
        movimientoRectilineo = GetComponent<MR>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            move = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            move = false;
             movimientoRectilineo.StopSequence();
        }
    }


    private void FixedUpdate()
    {
		//Distancia recorrida desde el origen.
		distanceTravelled += Vector3.Distance(transform.position, lastPosition);
  		lastPosition = transform.position;
		 
		//CountFlips();
        if (move)
        {
            if (isGrounded){
                 rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
                //movimientoRectilineo.acceleracion = this.acceleracion;
                //movimientoRectilineo.movimientoActivo = true;
            }
            else{
                
                rb.AddTorque(rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
                movimientoRectilineo.StopSequence();
            }
        }
        upsideDown = Vector2.Dot(transform.up, Vector2.down);
        if (isGrounded && (upsideDown > 0)) //Si el jugador esta alrevez 
        {
            //StartCoroutine(RestartLevel());
			Debug.Log("Alrevez");
        }
    }


	private void CountFlips()
     {
		
         if ((transform.rotation.eulerAngles.z > 270f) && (transform.rotation.eulerAngles.z < 300f))
         {
             Debug.Log(String.Format("flipped with value {0}", transform.rotation.eulerAngles.z));
		 }
            
     }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }


    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f);
        //if (isGrounded && (upsideDown > 0)
     //       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
