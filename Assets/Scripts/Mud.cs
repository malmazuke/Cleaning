using UnityEngine;
using System.Collections;

public class Mud : MonoBehaviour {

    [HideInInspector]
    public MudController mudController;

    void OnTriggerEnter (Collider other) {
        if (other.tag != "PlayerHand") {
            return;
        }

        mudController.MudPatchDestroyed ();
        Destroy (gameObject);
    }
}
