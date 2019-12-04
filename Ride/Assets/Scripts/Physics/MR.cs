using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR : MonoBehaviour
{

    public bool movimientoActivo = false;
    public Vector3 velocidad = Vector3.zero;
    public Vector3 acceleracion = new Vector3(5f, 0f, 0);
    public Vector3 Posicion = Vector3.zero;




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (movimientoActivo)
        {
            Posicion = velocidad * Time.deltaTime +  acceleracion * (Mathf.Pow(Time.deltaTime, 2) / 2);
            gameObject.transform.Translate(Posicion);
            
            velocidad += acceleracion * Time.deltaTime;
        }
        else
        {
            return;
        }

    }

    public void StopSequence(){
        
        StartCoroutine(Stop());
    }

    public IEnumerator Stop(){

         yield return new WaitForSeconds(0.2f);
         this.movimientoActivo = false;
         this.velocidad = Vector3.zero;
       
    }
}
