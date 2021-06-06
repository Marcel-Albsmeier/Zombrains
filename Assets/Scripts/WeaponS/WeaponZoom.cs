using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.InputSystem;

public class WeaponZoom : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] Camera fpsPlayerCamera;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] float zoomedInFOV = 30f;

    [SerializeField] float regularSens = 2f;
    [SerializeField] float zoomSens = 1f ;

    [SerializeField] InputAction zoomToggleKey;

    //cached 
    RigidbodyFirstPersonController fpsController;

    private void OnEnable() {
        zoomToggleKey.Enable();
    }

    private void OnDisable() {
        zoomToggle = false;
        ZoomOut();
        zoomToggleKey.Disable();
    }

    private void Awake() {
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    bool zoomToggle = false;
    private void Update() {
        if (zoomToggleKey.triggered) {
            zoomToggle = !zoomToggle;

            if (zoomToggle) {
                ZoomIn();
            } else {
                ZoomOut();
            }
        }
    }

    private void ZoomOut() {
        fpsPlayerCamera.fieldOfView = defaultFOV;
        fpsController.mouseLook.XSensitivity = regularSens;
        fpsController.mouseLook.YSensitivity = regularSens;
    }

    private void ZoomIn() {
        fpsPlayerCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomSens;
        fpsController.mouseLook.YSensitivity = zoomSens;
    }
}
