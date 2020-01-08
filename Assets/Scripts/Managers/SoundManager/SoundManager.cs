using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField]
    private SoundTable _soundTable = null;

    private AudioSource _audioSource;

    private Dictionary<SoundType, AudioClip> soundList
        = new Dictionary<SoundType, AudioClip>();

    protected override void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        InitializeSoundList();
    }

    private void InitializeSoundList()
    {
        for (int i = 0; i < _soundTable.audioClipList.Count; i++)
        {
            soundList.Add((SoundType)i, _soundTable.audioClipList[i]); ;
        }
    }

    public void PlaySoundOneShot(SoundType type)
    {
        _audioSource.PlayOneShot(soundList[type]);
    }
}
