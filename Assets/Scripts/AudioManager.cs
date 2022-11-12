using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    //Help from Brackey's https://www.youtube.com/watch?v=6OT43pvUyfY
    //Unity's audio system is not fun to use. If tired of, buy Sonity OR download Fmod
    //https://assetstore.unity.com/packages/tools/audio/sonity-audio-middleware-229857
    //https://assetstore.unity.com/packages/tools/audio/fmod-for-unity-161631


    public static AudioManager instance;
    public Sound[] sounds;

    void Awake() {
        //Singleton.
        if (AudioManager.instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogError($"Could not find {name} sound");
            return;
        }
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        StartCoroutine(playAndDelete(s.source));
        s.source.Play();
    }

    private IEnumerator playAndDelete(AudioSource source) {
        source.Play();
        //Length of audio is inversely proportional to the pitch 
        yield return new WaitForSeconds(source.clip.length * (1/source.pitch));
        Destroy(source);
    }
}
