using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof(BoxCollider) )]
public class TriggerVolume : MonoBehaviour
{
    [SerializeField] UnityEvent _onTrigger;
    [SerializeField] string tag;

    void OnValidate()
    {
        if ( TryGetComponent( out BoxCollider col ) )
            col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if ( other.name.Contains( tag ) )
            _onTrigger?.Invoke();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color( 1, 1, 0, 0.5f );
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube( Vector3.zero, Vector3.one );
    }
}
