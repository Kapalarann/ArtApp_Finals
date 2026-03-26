using System.Collections;
using UnityEngine;

public class PineappleTeleport : MonoBehaviour
{
    [SerializeField] Transform _newTransformTarget;
	[SerializeField] bool _followNewTargetRotation;

    FirstPersonCamera _cam;

    IEnumerator Start()
    {
        yield return Bootstrapper.WaitUntilBootstrapIsLoaded();

        _cam = FindFirstObjectByType<FirstPersonCamera>();

        GameObject p = GameObject.FindGameObjectWithTag( "Player" );
        if ( p == null )
        {
            Debug.LogWarning( "NO PLAYER. PLEASE LOAD MAIN SCENE IF U WANT PLAYER" );
            yield break;
        }

        p.GetComponent<Rigidbody>().MovePosition( transform.position );
        p.GetComponent<Rigidbody>().rotation = transform.rotation;

        if ( _newTransformTarget != null )
        {
            _cam.SetFollowTarget( _newTransformTarget, useOffset: true, offset: Vector3.zero, followRotation: _followNewTargetRotation );
        }
    }

    void OnDisable()
    {
        if ( _cam != null )
            _cam.ResetTarget();
    }
}
