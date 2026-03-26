using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    float _mouseSens;

    [SerializeField]
    Transform _followTarget;
    Transform _lastTarget;
	[SerializeField] bool _shouldFollowRotation;
	bool _lastShouldFollowRot;

    [SerializeField] bool _useLocalTransform;

    [SerializeField] Vector3 _offset = Vector3.up;
    Vector3 _lastOffset;

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

		if ( _shouldFollowRotation )
		{
			_mouseX = Mathf.Clamp( _mouseX, -25, 25 );
			_mouseY = Mathf.Clamp( _mouseY, -25, 25 );

			transform.rotation = _followTarget.rotation * Quaternion.Euler( _mouseY, _mouseX, 0 ); // NOTE(seifer): "adding" quaternions = multiply them
		}
		else
		{
			transform.rotation = Quaternion.Euler( _mouseY, _mouseX, 0 );
		}
    }

    void LateUpdate()
    {
        var offset = _offset;
        if ( _useLocalTransform )
            offset = _followTarget.TransformDirection( _offset );

        transform.position = _followTarget.position + offset;
    }

    public void SetFollowTarget( Transform newTarg, bool useOffset = false, Vector3 offset = default, bool followRotation = false )
    {
        _lastTarget = _followTarget;
        _followTarget = newTarg;
        _lastOffset = _offset;
		_lastShouldFollowRot = _shouldFollowRotation;
		_shouldFollowRotation = followRotation;

        if ( useOffset )
            _offset = offset;
    }

    public void ResetTarget()
    {
        if ( _lastTarget == null )
            return;

        _followTarget = _lastTarget;
		_shouldFollowRotation = _lastShouldFollowRot;
        _lastTarget = null;

        _offset = _lastOffset;
    }
}
