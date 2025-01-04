using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10f;
    //private int desiredLine = 1; // 0:left 1: middle 2: right
    //public float laneDistance = 4f;
    public float rotationSpeed = 5f; // Velocidad de giro
    public float jumpForce = 10;
    public float gravity = -20;
    private float currentRotationY = 0; // Rotación actual
    void Start(){
        controller = GetComponent<CharacterController>();
        if (controller == null) Debug.LogError("CharacterController no encontrado. Asegúrate de que este script esté en un GameObject con un CharacterController.");
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
            //desiredLine++;
            //if (desiredLine == 3) desiredLine = 2;
            currentRotationY += rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //desiredLine--;
            //if (desiredLine == -1) desiredLine = 0;
            currentRotationY -= rotationSpeed * Time.deltaTime;
        }
        
        // Calcular donde deberia estar en el futuro
        Vector3 zeta = transform.position.z * transform.forward; // escalar * vector3
        Vector3 ye = transform.position.y * transform.up;
        Vector3 targetPosition = zeta + ye;

        //if (desiredLine == 0) {
        //    targetPosition += Vector3.left * laneDistance;
        //} else if (desiredLine == 2) {
        //    targetPosition += Vector3.right * laneDistance;
        //}
        //transform.position = targetPosition;
        //transform.position = Vector3.Lerp(transform.position, targetPosition,80*Time.deltaTime);

        // Aplica la rotación suavemente
        Quaternion targetRotation = Quaternion.Euler(0, currentRotationY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Movimiento hacia adelante
        direction = transform.forward * forwardSpeed + Vector3.up * direction.y;
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