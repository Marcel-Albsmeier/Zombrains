using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour{

    //parameters
    [SerializeField] float impactTime = 0.2f;

    //cached references
    [SerializeField] Canvas impactCanvas;

    // Start is called before the first frame update
    void Start(){
        impactCanvas.enabled = false;
    }

    public void DisplayDamageImpact() {
        StartCoroutine(ShowSplatter());
    
    }

    IEnumerator ShowSplatter() {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
