using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof(BoxCollider) )]
public class TriggerVolume : MonoBehaviour
{
    [SerializeField] UnityEvent _onTrigger;
    [SerializeField] bool _checkName;
    [SerializeField] string[] _names;

    [SerializeField] string _loadSceneOnPlayerHit;

    void OnValidate()
    {
        if ( TryGetComponent( out BoxCollider col ) )
            col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if ( !_checkName )
        {
            if ( other.CompareTag( "Player" ) )
            {
                _onTrigger?.Invoke();

                if ( !string.IsNullOrEmpty( _loadSceneOnPlayerHit ) )
                    SceneLoader.Instance.Load( _loadSceneOnPlayerHit );
            }
        }
        else
        {
            if ( _names.Any( s => other.name.Contains( s ) ) )
                _onTrigger?.Invoke();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color( 1, 1, 0, 0.5f );
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube( Vector3.zero, Vector3.one );
    }
}
