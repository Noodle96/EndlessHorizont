using UnityEngine;

public class OrientationManager :MonoBehaviour {
    void Awake() {
        // Permitir rotaci�n autom�tica solo en Landscape
        Screen.autorotateToPortrait = false; // Desactiva rotaci�n vertical
        Screen.autorotateToPortraitUpsideDown = false; // Desactiva vertical invertido
        Screen.autorotateToLandscapeLeft = true; // Activa Landscape Left
        Screen.autorotateToLandscapeRight = true; // Activa Landscape Right

        // Habilitar rotaci�n autom�tica
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
