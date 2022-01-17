using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour
{
    public GameObject destroyedPig;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            Destroy(gameObject);
            GameObject scateredObj = Instantiate(destroyedPig, other.transform.position, Quaternion.identity);
            Destroy(scateredObj, 3);
        }
    }
}
