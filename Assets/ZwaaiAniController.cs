using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZwaaiAniController : MonoBehaviour
{
      Animator anim;
	AnimatorOverrideController animOverrideController;
    AnimationClip animationClip;
    protected Animator animator;
    protected AnimatorOverrideController animatorOverrideController;

    public Animator zwaaiAnim;
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
        if(Input.GetKeyDown("space")){
            animator.Play("Wave");
        }
        if(Input.GetKeyDown("p")){
             animationClip = ClipStorage.animationClip;
	    	animatorOverrideController["testAnimation"]= animationClip;
		    animator.runtimeAnimatorController= animatorOverrideController;
            animator.Play("PlayerAnim");
        }
    }
}
