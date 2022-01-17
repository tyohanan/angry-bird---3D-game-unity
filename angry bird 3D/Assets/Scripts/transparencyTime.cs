using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparencyTime : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer rendererBird;
    private Color colorbird;
    private float decreaseTransparency;
    
    private void Start() {
        decreaseTransparency = 1f;

    }

    private void Update() {
        if (decreaseTransparency > 0){
             decreaseTransparency -= Time.deltaTime*0.3f;
        }
        colorbird = rendererBird.material.color;
        colorbird.a = decreaseTransparency;
        rendererBird.material.color = colorbird;
        Debug.Log(colorbird.a);
    }
}