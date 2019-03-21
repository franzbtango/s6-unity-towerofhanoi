using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioSource Source { get; set; }

    public string name;
    public AudioClip clip;
    public bool loop;
}
