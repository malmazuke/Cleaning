using UnityEngine;
using System.Collections;

public class HandsFollow : MonoBehaviour {

    #region Public Properties

    public GameObject IKTarget;
    public bool isPlayerOne = true;

    #endregion

    #region Private Properties

    private Animator animator;

    #endregion

    #region Unity Methods

    void Awake () {
        animator = GetComponent<Animator>();
    }
    
    void OnAnimatorIK(int layerIndex) {
        if (animator == null) {
            return;
        }
        
        if (IKTarget != null) {
            AvatarIKGoal hand = isPlayerOne ? AvatarIKGoal.LeftHand : AvatarIKGoal.RightHand;
            animator.SetIKPositionWeight (hand, 1.0f);
            animator.SetIKRotationWeight (hand, 1.0f);
            animator.SetIKPosition (hand, IKTarget.transform.position);
            animator.SetIKRotation (hand, IKTarget.transform.rotation);
        }
    }

    #endregion
}
