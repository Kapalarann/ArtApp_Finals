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
            _onTrigger?.Invoke();
        }
        else if ( _checkName && _names.Contains( other.name ) )
        {
            _onTrigger?.Invoke();
        }

        if ( other.CompareTag( "Player" ) && !string.IsNullOrEmpty( _loadSceneOnPlayerHit ) )
            SceneLoader.Instance.Load( _loadSceneOnPlayerHit );
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color( 1, 1, 0, 0.5f );
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube( Vector3.zero, Vector3.one );
    }
}
