using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorControl : MonoBehaviour
{

    private string direccion = "Arriba";
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direccion.Equals("Arriba"))
         transform.Translate(Vector3.up*movementSpeed*Time.deltaTime);
         else
         {
            if (direccion.Equals("Abajo"))
            {
                transform.Translate(Vector3.down*movementSpeed*Time.deltaTime);
            }
         }

          
    } 

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Techo"))
        {
            direccion = "Abajo";
            //print("Abajo");
           // transform.Translate(Vector3.down*movementSpeed*Time.deltaTime);
        }
        if (other.gameObject.CompareTag("Suelo"))
        {
            direccion = "Arriba";
            //print("Arriba");
            //transform.Translate(Vector3.up*movementSpeed*Time.deltaTime);
        }
    }
    
 
}
