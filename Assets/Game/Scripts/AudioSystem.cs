using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    public void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
