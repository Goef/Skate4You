using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animation))]

public class recordAnimation : MonoBehaviour
{
public GameObject PlayerMovement;
public Animation anim;
	AnimationClip animationClip;

	void Start () {
		anim = PlayerMovement.GetComponent<Animation> ();
		// define animation curve
		AnimationCurve translateX = AnimationCurve.Linear(0.0f, 0.0f, 2.0f, 2.0f);
		animationClip = new AnimationClip();
		// set animation clip to be legacy
		animationClip.legacy = true;
		animationClip.SetCurve("", typeof(Transform), "localPosition.x", translateX);
		anim.AddClip(animationClip, "test");
		anim.Play("test");
	}
}