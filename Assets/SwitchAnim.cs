using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnim : MonoBehaviour
{
        // dit is van link http://gyanendushekhar.com/2018/03/18/create-play-animation-runtime-unity-tutorial/
    Animator anim;
	AnimatorOverrideController animOverrideController;
    AnimationClip animationClip;
    protected Animator animator;
    protected AnimatorOverrideController animatorOverrideController;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown("v")){
        animationClip = ClipStorage.animationClip;
		animatorOverrideController["testAnimation"]= animationClip;
		animator.runtimeAnimatorController= animatorOverrideController;

        }
    }
}
