using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*1*Time.deltaTime);
    }
     private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            print("Checkpoint");
        }    
    }
}
