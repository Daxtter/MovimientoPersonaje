using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    
    public float distance;
    public float visionAngle;
    public LayerMask objectLayer;
    public LayerMask distanceLayers;
    public LayerMask obstaclesLayers; 
    public Collider detectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         detectedObject = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position,distance, objectLayer);
        for ( int  i = 0; i<colliders.Length; i++)
        {
            Collider collider = colliders[i];
            Vector3 directionToObject = Vector3.Normalize(collider.bounds.center - transform.position);
            float angleToCollider = Vector3.Angle(transform.forward,directionToObject);
            if (angleToCollider <visionAngle)
            {
                if(!Physics.Linecast(transform.position, collider.bounds.center, (int) obstaclesLayers))
                {
                    
                    Debug.DrawLine(transform.position, collider.bounds.center);
                    detectedObject = collider;
                    
                    break;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,distance);
        Vector3 rigthDirection = Quaternion.Euler(0,visionAngle,0)*transform.forward;
        Gizmos.DrawRay(transform.position, rigthDirection*distance);
        Vector3 leftDirection = Quaternion.Euler(0,-visionAngle,0)*transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection*distance);
    }
    
}
