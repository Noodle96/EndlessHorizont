using UnityEngine;

public class PlayerController :MonoBehaviour {
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10f;
    public float turnSpeed = 100f; // Velocidad de giro
    public float gravity = -20f;

    void Start() {
        controller = GetComponent<CharacterController>();
        if (controller == null) {
            Debug.LogError("CharacterController no encontrado.");
        }
        direction.z = forwardSpeed;
    }

    void Update() {
        // Movimiento hacia adelante
        direction = transform.forward * forwardSpeed;

        // Controles combinados para girar a la izquierda
        if (SwipeManager.pressLeft || Input.GetKey(KeyCode.LeftArrow)) {
            RotateLeft();
        }

        // Controles combinados para girar a la derecha
        if (SwipeManager.pressRight || Input.GetKey(KeyCode.RightArrow)) {
            RotateRight();
        }

        // Aplicar gravedad si es necesario (por ejemplo, para pendientes)
        direction.y += gravity * Time.deltaTime;
    }

    private void FixedUpdate() {
        // Mover al jugador en la dirección calculada
        controller.Move(direction * Time.deltaTime);
    }

    private void RotateLeft() {
        // Girar a la izquierda
        transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
    }

    private void RotateRight() {
        // Girar a la derecha
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
