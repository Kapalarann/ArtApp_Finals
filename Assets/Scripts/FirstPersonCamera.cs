using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    float _mouseSens;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw( "Mouse X" ) * _mouseSens; 
        float mouseY = Input.GetAxisRaw( "Mouse Y" ) * _mouseSens;
        
        transform.Rotate( new Vector3( -mouseY, mouseX, 0 ) );
    }
}
