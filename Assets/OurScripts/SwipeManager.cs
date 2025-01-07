using UnityEngine;

public class SwipeManager :MonoBehaviour {
    public static bool pressLeft, pressRight;

    private void Update() {
        // Reiniciar valores cada frame
        pressLeft = false;
        pressRight = false;

        // Detectar entrada táctil o clic
        if (Input.GetMouseButton(0)) // Detección en PC (clic del ratón)
        {
            Vector2 touchPosition = Input.mousePosition;
            if (touchPosition.x < Screen.width / 2) {
                pressLeft = true; // Si está en la mitad izquierda
            } else {
                pressRight = true; // Si está en la mitad derecha
            }
        } else if (Input.touchCount > 0) // Detección en dispositivos móviles
          {
            Vector2 touchPosition = Input.touches[0].position;
            if (touchPosition.x < Screen.width / 2) {
                pressLeft = true; // Si está en la mitad izquierda
            } else {
                pressRight = true; // Si está en la mitad derecha
            }
        }
    }
}