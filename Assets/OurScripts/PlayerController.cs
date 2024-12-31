using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Debug.LogWarning("Controller: "+ controller);
        if (controller == null)
        {
            Debug.LogError("CharacterController no encontrado. Asegúrate de que este script esté en un GameObject con un CharacterController.");
        }

        direction.z = forwardSpeed;
        //Debug.LogWarning("direction: " + direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // Time.deltaTime es el tiempo que paso desde el ultimo frame = 0.02 aprox
        Vector3 directionInterval = direction  * Time.deltaTime;
        controller.Move(directionInterval);
        //Debug.Log("move: " + directionInterval);
    }
}
