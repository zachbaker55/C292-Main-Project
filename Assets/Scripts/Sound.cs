using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {
    //Help from Brackey's https://www.youtube.com/watch?v=6OT43pvUyfY
    
    public string name;
    public AudioClip clip;

    [Range(0f,1f)] public float volume;
    [Range(0.1f,1f)] public float pitch;

    [HideInInspector] public AudioSource source;

}
