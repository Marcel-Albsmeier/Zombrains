using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour{
    //parameters
    [Header("Parameters")]
    [Tooltip("The rate at which the light intensity is reduced per second.")]
    [SerializeField] float lightIntensitiyDecayRate = 0.1f;
    float lightIntensityStartingValue;
    [Tooltip("The rate at which the angle of the light cone is reduced per second, in degrees.")]
    [SerializeField] float lightAngleDecayRate = 1f;
    [SerializeField] float lightAngleMinimumValue = 15f;
    float lightAngleStartingValue;

    //cached references
    Light flashLight;

    private void Awake() {
        flashLight = GetComponent<Light>();
        lightIntensityStartingValue = flashLight.intensity;
        lightAngleStartingValue = flashLight.spotAngle;
    }

    private void Update() {
        DecayAngle();
        DecayIntensity();
    }

    private void DecayAngle() {
        if (flashLight.spotAngle <= lightAngleMinimumValue) {
            return;
        }
        flashLight.spotAngle -= lightAngleDecayRate * Time.deltaTime;
    }

    private void DecayIntensity() {
        flashLight.intensity -= lightIntensitiyDecayRate * Time.deltaTime;        
    }

    public void RechargeBattery() {
        flashLight.intensity = lightIntensityStartingValue;
        flashLight.spotAngle = lightAngleStartingValue;
    }    
    
    public void RechargeBattery(float restoreAngleAmount, float restoreIntensityAmount) {
        RestoreLightIntensity(restoreIntensityAmount);
        RestoreLightAngle(restoreAngleAmount);
    }

    private void RestoreLightAngle(float degrees) {
        flashLight.spotAngle = Mathf.Clamp(
            flashLight.spotAngle + degrees, 
            lightAngleMinimumValue, 
            lightAngleStartingValue);
    }

    private void RestoreLightIntensity(float amount) {
        flashLight.intensity = Mathf.Clamp(
            flashLight.intensity + amount, 0, lightIntensityStartingValue);
    }
}
