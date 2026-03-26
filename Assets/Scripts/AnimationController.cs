using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationController : MonoBehaviour
{
    Animation _animation;
    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    public void Play(string animationClip)
    {
        if ( string.IsNullOrEmpty( animationClip ) )
            return;
        _animation.Play(animationClip);
    }
}
