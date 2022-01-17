using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse3DPosition : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public LayerMask catapultsRadius;
    public Vector3 mousePosition3D;

    private MeshRenderer visibility;
    private void Start() {
        visibility = GetComponent<MeshRenderer>();
        visibility.enabled = false;
    }

    private void Update() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, catapultsRadius)){
            visibility.enabled = true;
            transform.position = raycastHit.point;
            mousePosition3D = raycastHit.point;
        }
        else{
            visibility.enabled = false;
        }
    }
}
