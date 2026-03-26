using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    float _mouseSens;

    [SerializeField]
    Transform _followTarget;

    [SerializeField] Vector3 _offset = Vector3.up;

    float _mouseX, _mouseY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _mouseX += Input.GetAxisRaw( "Mouse X" ) * _mouseSens; 
        _mouseY = Mathf.Clamp( _mouseY - Input.GetAxisRaw( "Mouse Y" ) * _mouseSens, -90, 90 );

        transform.rotation = Quaternion.Euler( _mouseY, _mouseX, 0 );
    }

    void LateUpdate()
    {
        transform.position = _followTarget.position + _offset;
    }
}
