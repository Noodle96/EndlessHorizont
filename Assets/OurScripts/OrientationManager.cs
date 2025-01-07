using UnityEngine;

public class OrientationManager :MonoBehaviour {
    void Awake() {
        // Permitir rotación automática solo en Landscape
        Screen.autorotateToPortrait = false; // Desactiva rotación vertical
        Screen.autorotateToPortraitUpsideDown = false; // Desactiva vertical invertido
        Screen.autorotateToLandscapeLeft = true; // Activa Landscape Left
        Screen.autorotateToLandscapeRight = true; // Activa Landscape Right

        // Habilitar rotación automática
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
