using UnityEngine;

[RequireComponent( typeof(Rigidbody) )]
public class Conveyer : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;

    [SerializeField]
    Rigidbody _rb;

    void OnValidate()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        _rb.position -= _speed * Time.deltaTime * transform.forward;
        _rb.MovePosition( _rb.position + _speed * Time.deltaTime * transform.forward );
    }
}
