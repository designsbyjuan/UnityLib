using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {
  
  private AudioSource audioSource;
  public AudioClip[] levelMusicArray;

  void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }

  // Use this for initialization
  void Start () {
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = levelMusicArray[0];
    audioSource.Play();
  }

  public void PlayAudioClip(int audioTrack)
  {
    AudioClip audioClip = levelMusicArray[audioTrack];

    if (audioClip)
    {
      audioSource.Stop();
      audioSource.clip = audioClip;
      audioSource.Play();
    }
  }

}
