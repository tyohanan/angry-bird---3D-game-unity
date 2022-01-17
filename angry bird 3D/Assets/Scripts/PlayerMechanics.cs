using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{

    private bool isMouseDown;


    public float maxLength = 100f;
    public float bottomBoundary = 0f;
    public float birdPositionOffset = 1;
    public float force;
    private float countDownTime;


    public GameObject playerPrefab;
    private Rigidbody birdRigidbody;
    private BoxCollider birdCollider;


    public Transform idlePosition;
    public Transform center;
    private Vector3 currentPosition;

    public Mouse3DPosition mousePos3D;

    void Start()
    {
        countDownTime = 0;
        CreateBird();
    }

    void CreateBird(){
        birdRigidbody = Instantiate(playerPrefab).GetComponent<Rigidbody>();
        birdCollider = playerPrefab.GetComponent<BoxCollider>();
        ResetStrips();
    }


    void Update()
    {
        countDownTime -= Time.deltaTime;
        // Debug.Log(isMouseDown);
        if (isMouseDown){
            Vector3 mousePosition = mousePos3D.mousePosition3D;
            // Debug.Log("mouse position " + mousePosition);
            // currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = mousePosition;
            // Debug.Log("screentoworldpoint " + currentPosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
            currentPosition = ClampBoundary(currentPosition);
            SetStrips(currentPosition);
        }
    }

    private void OnMouseDown() {
        if (countDownTime < 0){
            isMouseDown = true;
            birdCollider.enabled = false;
            birdRigidbody.isKinematic = true;
        }
    }

    private void OnMouseUp() {
        isMouseDown = false;
        Shoot();
        countDownTime = 1f;
        Invoke("CreateBird", 1f);
    }

    void Shoot(){
        birdRigidbody.isKinematic = false;
        birdCollider.enabled = true;
        Vector3 BirdForce = (currentPosition - center.position) *force*-1;
        birdRigidbody.velocity = BirdForce;
    }

    void SetStrips(Vector3 position){
        Vector3 dir = position - center.position;
        // birdRigidbody.transform.position = position;

        birdRigidbody.transform.position = position + dir.normalized * birdPositionOffset;
        birdRigidbody.transform.forward = - dir.normalized;
    }

    void ResetStrips(){
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    Vector3 ClampBoundary (Vector3 vector){
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
}
