using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource[] m_AudioSource; 

    void Play()
    {
        foreach (var audioSource in m_AudioSource) { audioSource.Play(); }
    }
}
