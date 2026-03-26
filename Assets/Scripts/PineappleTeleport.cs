using Unity.Cinemachine;
using UnityEngine;

public class PineappleTeleport : MonoBehaviour
{
    [SerializeField] Vector3 _startRotation;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag( "Player" );
        if ( p == null )
        {
            Debug.LogWarning( "NO PLAYER. PLEASE LOAD MAIN SCENE IF U WANT PLAYER" );
            return;
        }
        
        // CinemachineCamera fc = FindFirstObjectByType<CinemachineCamera>();
        // fc.enabled = false;

        p.GetComponent<Rigidbody>().MovePosition( transform.position );
        p.GetComponent<Rigidbody>().rotation = Quaternion.Euler( _startRotation );
        // fc.transform.position = transform.position;

        // fc.enabled = true;
    }
}
