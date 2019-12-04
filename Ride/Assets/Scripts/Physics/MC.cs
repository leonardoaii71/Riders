using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : MonoBehaviour
{
    // Start is called before the first frame update
    public bool movimientoActivo = false;
    Vector3 velocidadFinal = Vector3.zero;
    Vector3 aceleracion = new Vector3(1, 1);
    float radio;
    Vector3 centro = Vector3.zero;
    Vector3 angulo = Vector3.zero;
    float tiempoEnganche;
    // Start is called before the first frame update
    void Start()
    { 
      // EstablecerCentro(new Vector3(0, -9.5f));
    }

    public void EstablecerCentro(Vector3 nuevoCentro){
        centro = nuevoCentro;
        radio = (float)calcularDistancia(nuevoCentro, gameObject.transform.position);
        tiempoEnganche = Time.time;

    }

    double calcularDistancia(Vector3 punto1, Vector3 punto2){
        return Mathf.Sqrt(
            Mathf.Pow(punto1.x - punto2.x, 2) + 
            Mathf.Pow(punto1.y - punto2.y, 2)  
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (centro == Vector3.zero || !movimientoActivo)
        {       
            return;
        }

            angulo = velocidadFinal * (Time.time - tiempoEnganche) / radio;
            gameObject.transform.position = new Vector3(
            centro.x + radio * Mathf.Cos(angulo.x), 
            centro.y + radio * Mathf.Sin(angulo.y)            
            );

        velocidadFinal += aceleracion * Time.deltaTime;
    }
   
}
