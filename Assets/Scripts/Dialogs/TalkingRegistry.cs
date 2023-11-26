using System;
using UnityEngine;

namespace Dialogs
{
    [CreateAssetMenu(fileName = "TalkingRegistry", menuName = "Registries/TalkingRegistry", order = 0)]
    public class TalkingRegistry : ScriptableObject
    {
        [SerializeField] private SpeechData _speeches;

        public SpeechData Speeches => _speeches;
    }

    [Serializable]
    public class SpeechData
    {
        [SerializeField] private string _idStoryteller;
        [TextAreaAttribute][SerializeField] private string _speech;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private float _timeOfTalk;

        public string Speech => _speech;

        public AudioClip Clip => _audioClip;

        public float TimeOfTalk => _timeOfTalk;

        public string IDStoryteller => _idStoryteller;
    }
}