using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioSource TargetAudioSource;

    [Header("Background Music for each Scene")]
    public AudioClip MainMenuMusic;
    public AudioClip ControlsMusic;
    public AudioClip LevelEditorMusic;
    public AudioClip LevelListMusic;
    public AudioClip GameMusic;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 1: CheckSoundClipIfEqualAndChangeIfNot(MainMenuMusic); break;
            case 2: CheckSoundClipIfEqualAndChangeIfNot(LevelEditorMusic); break;
            case 3: CheckSoundClipIfEqualAndChangeIfNot(GameMusic); break;
            case 4: CheckSoundClipIfEqualAndChangeIfNot(ControlsMusic); break;
            case 5: CheckSoundClipIfEqualAndChangeIfNot(LevelListMusic); break;
            default: break;
        }
    }

    private void CheckSoundClipIfEqualAndChangeIfNot(AudioClip clip)
    {
        if(clip != TargetAudioSource.clip)
        {
            TargetAudioSource.clip = clip;
            TargetAudioSource.Play();
        }
    }
}
