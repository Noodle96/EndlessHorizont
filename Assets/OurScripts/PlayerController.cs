using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10f;
    private int desiredLine = 1; // 0:left 1: middle 2: right
    public float laneDistance = 4f;
    public float jumpForce = 10;
    public float gravity = -20;
    void Start(){
        controller = GetComponent<CharacterController>();
        if (controller == null) Debug.LogError("CharacterController no encontrado. Aseg�rate de que este script est� en un GameObject con un CharacterController.");
        direction.z = forwardSpeed;
    }

    void Update(){
        if (controller.isGrounded) {
            //direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();
        } else {
            direction.y += gravity * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            desiredLine++;
            if (desiredLine == 3) desiredLine = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLine--;
            if (desiredLine == -1) desiredLine = 0;
        }
        
        // Calcular donde deberia estar en el futuro
        Vector3 zeta = transform.position.z * transform.forward; // escalar * vector3
        Vector3 ye = transform.position.y * transform.up;
        Vector3 targetPosition = zeta + ye;
   
        if (desiredLine == 0) {
            targetPosition += Vector3.left * laneDistance;
        } else if (desiredLine == 2) {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = targetPosition;
        //transform.position = Vector3.Lerp(transform.position, targetPosition,80*Time.deltaTime);
    }
    private void FixedUpdate(){
        // Time.deltaTime es el tiempo que paso desde el ultimo frame = 0.02 aprox
        Vector3 directionInterval = direction  * Time.deltaTime;
        controller.Move(directionInterval);
        //Debug.Log("move: " + directionInterval);
    }
    private void Jump() {
        direction.y = jumpForce;
    }
}


// Anotations
//Debug.LogWarning(Vector3.right); // (1,0,0)
//Debug.LogWarning(Vector3.left); // (-1,0,0)
//Debug.LogWarning(Vector3.zero); // (0,0,0)
//Debug.LogWarning(Vector3.up); // (0,1,0)
//Debug.LogWarning(Vector3.down); // (0,-1,0)
//Debug.LogWarning(Vector3.forward); // (0,0,1)
//Debug.LogWarning(Vector3.back); // (0,0,-1)