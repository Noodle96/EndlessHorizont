using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        // La distancia fija que debe mantenerse entre la c�mara y el objetivo.
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        //transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        if (target == null) return;

        // Calcular la posici�n deseada de la c�mara.
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);

        // Ajustar la rotaci�n para mirar hacia el jugador.
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 0.1f);
    }
}
//Momento de ejecucion
// Update(): Antes de renderizar cada frame.	
// LateUpdate() : Despu�s de que todos los Update han terminado.