using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HSS {

    public class AnimationBehaviours : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void OnEnable()
        {
            SceneMgmt.OnPlayPressed += EnableAnimator;
        }

        private void OnDisable()
        {
            SceneMgmt.OnPlayPressed -= EnableAnimator;
        }

        void EnableAnimator() {
            animator.SetTrigger("ExecuteFade");
        }
    }
}
