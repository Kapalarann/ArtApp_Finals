using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Game Event" )]
public class GameEvent : ScriptableObject
{
    readonly List<GameEventListener> _evtListeners = new();

    public void Raise()
    {
        for ( int i = _evtListeners.Count - 1; i >= 0; i-- )
            _evtListeners[i].OnEventRaised();
    }

    public void Register( GameEventListener listener )
    {
        if ( !_evtListeners.Contains( listener ) ) _evtListeners.Add( listener );
    }

    public void Unregister( GameEventListener listener )
    {
        if ( _evtListeners.Contains( listener ) ) _evtListeners.Remove( listener );
    }
}
