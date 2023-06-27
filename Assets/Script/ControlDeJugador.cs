using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Character Controller es mejor
public class ControlDeJugador : MonoBehaviour
{
    //Campos asociados al movimiento del jugador 
    public float movementSpeed;
    public float maxSpeed = 10f;
    private float horizontal;
    private float vertical ; 
    public float jumpForce; 

    //Prefab asociada al proyectil que dispara el jugador
    public GameObject bullet;
    //Punto de referencia para la creación de la bala
    public GameObject bulletSpawner; 

public Transform cam; 
    private Rigidbody rb; 
    void Start()
    {

        rb=gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //print("Evento uptade")  ;
         //transform.Translate(0,0,1);
         
       // if(Input.GetKey(KeyCode.W))
       //     transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);
        //if(Input.GetKey(KeyCode.A))
        //    transform.Translate(Vector3.right*movementSpeed*Time.deltaTime);
        //if(Input.GetKey(KeyCode.S))
        //    transform.Translate(Vector3.back*movementSpeed*Time.deltaTime);
       // if(Input.GetKey(KeyCode.D))
       //     transform.Translate(Vector3.left*movementSpeed*Time.deltaTime);
         horizontal = Input.GetAxisRaw("Horizontal");
       vertical = Input.GetAxisRaw("Vertical");
       if(Input.GetKeyDown(KeyCode.Mouse0))
       {
        Instantiate(bullet,bulletSpawner.transform.position,bulletSpawner.transform.rotation);

       }        
       if (Input.GetKey(KeyCode.Space))
        {
           if(checkInGround())
                rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            
        }
       
       checkInGround();
        
    }
    void FixedUpdate() {
       
            //Se asocia el input vertical y/o horizontal hacia una direccion
        Vector3 direction = new Vector3(horizontal, 0f , vertical);
        //Se determina si hay movimiento
        if (direction.magnitude > 0){
            //Se calcula el angulo del movimiento para rotar la vista del jugador en funcion de la camara.
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            if(rb.velocity.magnitude <= maxSpeed)
                rb.AddForce(moveDirection * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }
    private bool checkInGround()
    {
        bool isGround = false;
        RaycastHit hit;
        Collider goColider = gameObject.GetComponent<BoxCollider>();
        float rayLength =goColider.bounds.size.y/4;
        Vector3 nuevo = new Vector3(0.1f,0.1f,0.1f);        
        
        if(Physics.Raycast(transform.position+nuevo, Vector3.down, out hit,rayLength))
        {
            Vector3 endPoint = new Vector3(transform.position.x,hit.transform.position.y, transform.position.z);
            Debug.DrawLine(transform.position,endPoint,Color.green);
            print(hit.transform.gameObject.name); 
            //Se revisa si hay colision por debajo  de ser asi entonces el jugador puede saltar 
            isGround = true;
        }
        return isGround;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
           // print("Checkpoint");
        }    
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))    
        {
           // print("En zona segura");
        }
    }
     private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))    
        {
           // print("Saliste de la zona segura");
        }
    }
}
