using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    float _mouseSens;

    [SerializeField]
    Transform _followTarget;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw( "Mouse X" ) * _mouseSens; 
        float mouseY = Input.GetAxisRaw( "Mouse Y" ) * _mouseSens;
        
        transform.Rotate( new Vector3( -mouseY, mouseX, 0 ) );
    }

    void LateUpdate()
    {
        transform.position = _followTarget.position;
    }
}
