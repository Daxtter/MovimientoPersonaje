using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeIA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Collider goColider = gameObject.GetComponent<BoxCollider>();
        float rayLength =4f;
        Vector3 nuevo = new Vector3(0.1f,0.1f,0.1f);        
        
        if(Physics.Raycast(transform.position+nuevo, Vector3.back, out hit,rayLength))
        {
            EnemyController control = gameObject.GetComponent<EnemyController>();
            Vector3 endPoint = new Vector3(transform.position.x,hit.transform.position.y, transform.position.z);
            Debug.DrawLine(transform.position,endPoint,Color.green);
            print(hit.transform.gameObject.name+"UO yeah");
            control.disparar(); 
            //Se revisa si hay colision por debajo  de ser asi entonces el jugador puede saltar 
            
        }
    }
}
