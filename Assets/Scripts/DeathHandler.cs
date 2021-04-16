using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour{
    //parameters
    [SerializeField] Canvas gameOverCanvas;

    //cached

    private void Start() {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath() {
        
        gameOverCanvas.enabled = true;
        var fpc = GetComponent<FirstPersonController>();
        fpc.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

    }

}
