using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] Camera fpsPlayerCamera;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] float zoomedInFOV = 30f;

    bool zoomToggle = false;
    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            zoomToggle = !zoomToggle;

            if (zoomToggle) {
                fpsPlayerCamera.fieldOfView = zoomedInFOV;
            } else {
                fpsPlayerCamera.fieldOfView = defaultFOV;
            }
        }
    }
}
