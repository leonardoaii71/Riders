using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

 


public class gameController : MonoBehaviour {
 
     public AudioClip reiniciarclip;
    public AudioSource audioSource;
    public TextMeshPro puntos;


    public static gameController instancia { get; private set; }
 
    private void Awake()
    {
        //referencia a este script 
        instancia = this;
       
    }
 
    private void Start()
    {
        TextMeshPro puntos = gameObject.GetComponent<TextMeshPro>();
    }
 
    public void GameOver(bool win)
    {
        StartCoroutine("GameOverSequence", win);
    }
 

    private IEnumerator GameOverSequence(bool win)
    {
        if (win)
        {
            
            audioSource.clip = reiniciarclip;
            audioSource.Play();
        
            yield return new WaitForSecondsRealtime(1f);
            //Feel free to set different values for knife count and log's rotation pattern
            //instead of just restarting. This would make it feel like a new, harder level.
            Reiniciar();
        }
      
    }
 
    public void Reiniciar()
    {
                
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
              
    }


}