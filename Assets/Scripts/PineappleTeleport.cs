using System.Collections;
using UnityEngine;

public class PineappleTeleport : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return Bootstrapper.WaitUntilBootstrapIsLoaded();

        GameObject p = GameObject.FindGameObjectWithTag( "Player" );
        if ( p == null )
        {
            Debug.LogWarning( "NO PLAYER. PLEASE LOAD MAIN SCENE IF U WANT PLAYER" );
            yield break;
        }
        
        // CinemachineCamera fc = FindFirstObjectByType<CinemachineCamera>();
        // fc.enabled = false;

        p.GetComponent<Rigidbody>().MovePosition( transform.position );
        p.GetComponent<Rigidbody>().rotation = transform.rotation;
        // fc.transform.position = transform.position;

        // fc.enabled = true;
    }
}
