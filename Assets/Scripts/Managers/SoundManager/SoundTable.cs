using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create SoundTable", fileName = "SoundTable")]
public class SoundTable : ScriptableObject
{
    public List<AudioClip> audioClipList
        = new List<AudioClip>();
}
