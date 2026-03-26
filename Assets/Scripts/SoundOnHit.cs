using UnityEngine;

public class SoundOnHit : MonoBehaviour
{
    [SerializeField] float _maxStrength;
    [SerializeField] AudioClip[] _sounds;

    public void OnCollisionEnter( Collision col )
    {
        var maxSq = _maxStrength * _maxStrength;
        var vol = Mathf.Clamp( col.relativeVelocity.sqrMagnitude, 0, maxSq ) / maxSq;
    }
}