using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyed : MonoBehaviour
{

    public GameObject destroyedBird;
    public GameObject explosion;

    public float expForce, radius;

    // List<GameObject> ScateredAll = new List<GameObject>();

    // private float decreaseTransparency;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy"){
            // decreaseTransparency = 1f;
            Destroy(gameObject);

            GameObject scateredObj = Instantiate(destroyedBird, other.transform.position, Quaternion.identity);
            GameObject explosionObj = Instantiate(explosion, other.transform.position, Quaternion.identity);
            knockback();
            Destroy(scateredObj, 3);
        }
    }

    // void invisibleBomb(){
    //         for (int i=0; i < scateredObj.transform.childCount; i++){
    //             // ScateredAll.Add(scateredObj.transform.GetChild(i).gameObject);

    //             if (decreaseTransparency > 0){
    //                 decreaseTransparency -= Time.deltaTime*0.3f;
    //             }
                
    //             Color transparent = scateredObj.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color;                
    //             transparent.a = decreaseTransparency;
    //             scateredObj.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = transparent;
    //             Debug.Log(decreaseTransparency);
    //         }
    // }

    void knockback(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders){
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if (rigg != null){
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }

}
