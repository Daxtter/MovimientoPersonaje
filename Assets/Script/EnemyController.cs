using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool disparoAutomatico;
    public GameObject bullet;
    //Salida de la bala
    public GameObject bulletSpawn;
     private float tiempoAEsperar = 1.0f;
    private float timer = 0.0f;
    private float scrollBar = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = scrollBar;
    }
   

  


    // Update is called once per frame
    void Update()
    {
        if (disparoAutomatico)
        {
            disparar();
        }
        
    }
    public void disparar()
    {
        timer += Time.deltaTime;

          if (timer > tiempoAEsperar)
        {
            Instantiate(bullet,bulletSpawn.transform.position,bulletSpawn.transform.rotation);

            // Remove the recorded 2 seconds.
            timer = timer - tiempoAEsperar;
            Time.timeScale = scrollBar;
            print("Aui");
        }
        print("Disparando");
    }
     
}
