using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent _event;
    [SerializeField] UnityEvent _onRaised;

    void OnEnable()
        => _event.Register( this );
        
    void OnDisable()
        => _event.Unregister( this );

    public void OnEventRaised()
        => _onRaised?.Invoke();
}