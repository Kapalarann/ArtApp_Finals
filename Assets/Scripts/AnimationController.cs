using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animation animation;
    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    public void Play(string animationClip)
    {
        animation.Play(animationClip);
    }
}
