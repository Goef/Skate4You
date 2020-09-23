using UnityEngine;
using System.Collections.Generic;

public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) { }

    public AnimationClip this[string name]
    {
        get { return this.Find(x => x.Key.name.Equals(name)).Value; }
        set
        {
            int index = this.FindIndex(x => x.Key.name.Equals(name));
            if (index != -1)
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
        }
    }
}

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private AnimationClip[] m_Animations;

    private Animator anim;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides clipOverrides;

    void Start()
    {
        anim = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = animatorOverrideController;

        clipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(clipOverrides);
    }

    public void Play(int numberClip)
    {
        clipOverrides["myAnimation"/*name *.anim file in State inspector*/] = m_Animations[numberClip];
        animatorOverrideController.ApplyOverrides(clipOverrides);
        anim.Play("start");

    }
}