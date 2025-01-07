using UnityEngine;

public class SwipeManager :MonoBehaviour {
    public static bool pressLeft, pressRight;

    private void Update() {
        // Reiniciar valores cada frame
        pressLeft = false;
        pressRight = false;

        // Detectar entrada t�ctil o clic
        if (Input.GetMouseButton(0)) // Detecci�n en PC (clic del rat�n)
        {
            Vector2 touchPosition = Input.mousePosition;
            if (touchPosition.x < Screen.width / 2) {
                pressLeft = true; // Si est� en la mitad izquierda
            } else {
                pressRight = true; // Si est� en la mitad derecha
            }
        } else if (Input.touchCount > 0) // Detecci�n en dispositivos m�viles
          {
            Vector2 touchPosition = Input.touches[0].position;
            if (touchPosition.x < Screen.width / 2) {
                pressLeft = true; // Si est� en la mitad izquierda
            } else {
                pressRight = true; // Si est� en la mitad derecha
            }
        }
    }
}