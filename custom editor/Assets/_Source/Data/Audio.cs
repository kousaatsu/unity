using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Audio
    {
        [field: SerializeField] public AudioClip Clip { get; private set; }

        [field: SerializeField][field: Range(0, 100)] public float Volume { get; private set; }
    }
}
