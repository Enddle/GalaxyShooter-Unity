using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    private Animator Anim = null;

    // Start is called before the first frame update
    void Start() {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            Anim.SetBool("TurnLeft", true);
            Anim.SetBool("TurnRight", false);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            Anim.SetBool("TurnLeft", false);
            Anim.SetBool("TurnRight", true);
        } else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
            Anim.SetBool("TurnLeft", false);
            Anim.SetBool("TurnRight", false);
        }
    }
}
