using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObject : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> children = new List<GameObject>();

    [SerializeField]
    private List<MeshRenderer> rendererBird = new List<MeshRenderer>();
    
    [SerializeField]
    private List<Color> colorbird = new List<Color>();
    private float decreaseTransparency;
    
    private void Start() {
        decreaseTransparency = 1f;

        for (int i = 0; i < children.Count; i++){
            // rendererBird.Add(children[i].GetComponent<MeshRenderer>());
            // colorbird.Add(rendererBird[i].material.color);
            rendererBird.Add(children[i].GetComponent<MeshRenderer>());
            colorbird.Add(rendererBird[i].material.color);
        }

    }

    private void Update() {
        if (decreaseTransparency > 0){
             decreaseTransparency -= Time.deltaTime*0.3f;
        }

    }
}
