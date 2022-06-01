using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;

    #region Don't Destroy Audio Manager on Load
    public static Audio_Manager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); // If we have problems with changing the audio manager between scenes, this is why

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    #endregion

    #region Play In Scenes
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            StopPlaying("FinalLevelTheme");
            StopPlaying("TutorialTheme");
            StopPlaying("Level01Theme");
            Play("MainMenuTheme");
        }
        if (SceneManager.GetActiveScene().name == "TutorialInterlude")
        {
            StopPlaying("FinalLevelTheme");
            StopPlaying("Level01Theme");
            StopPlaying("MainMenuTheme");
            Play("TutorialTheme");
        }
        if (SceneManager.GetActiveScene().name == "Level1Interlude")
        {
            StopPlaying("FinalLevelTheme");
            StopPlaying("MainMenuTheme");
            StopPlaying("TutorialTheme");
            Play("Level01Theme");
        }
        if (SceneManager.GetActiveScene().name == "FinalLevelInterlude")
        {
            StopPlaying("MainMenuTheme");
            StopPlaying("TutorialTheme");
            StopPlaying("Level01Theme");
            Play("FinalLevelTheme");
        }
    }
    #endregion

    #region Play and Stop
    public void Play(string name)
    { 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    #endregion
}
