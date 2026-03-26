using UnityEngine;

[RequireComponent( typeof(Rigidbody) )]
public class Conveyer : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;
    [SerializeField] Rigidbody _rb;

    bool _canMove = true;

    void OnValidate()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        if ( !_canMove )
            return;
            
        _rb.position -= _speed * Time.deltaTime * transform.forward;
        _rb.MovePosition( _rb.position + _speed * Time.deltaTime * transform.forward );
    }

    public void SetConveyerState( bool state )
        => _canMove = state;
}
