using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {

        // easy way

        // Destroy(this.gameObject, 5f);

        // better way

        // float length = this.GetComponent<Animator>().GetNextAnimatorStateInfo(0).length;

        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update() {

    }
}
