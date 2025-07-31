using System.Collections.Generic;
using TestTask.DataLayer;
using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.Sounds
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        private AudioSource _musicSource;
        private readonly Dictionary<string, AudioSource> _audioSources = new();

        public void PlaySfx(string sfxName)
        {
            if (!_audioSources.ContainsKey(sfxName))
            {
                var source = gameObject.AddComponent<AudioSource>();
                source.volume = GameDataProvider.Instance.SoundsDatabase.SoundsDictionary[sfxName].Volume;
                source.clip = GameDataProvider.Instance.SoundsDatabase.SoundsDictionary[sfxName].Clip;
                _audioSources.Add(sfxName, source);
            }
            
            _audioSources[sfxName].Stop();
            _audioSources[sfxName].Play();
        }
        
        public void PlayMusic(string musicName)
        {
            if (_musicSource == null)
            {
                _musicSource = gameObject.AddComponent<AudioSource>();
                _musicSource.loop = true;
            }
            
            _musicSource.volume = GameDataProvider.Instance.SoundsDatabase.SoundsDictionary[musicName].Volume;
            _musicSource.clip = GameDataProvider.Instance.SoundsDatabase.SoundsDictionary[musicName].Clip;
            _musicSource.Stop();
            _musicSource.Play();
        }
    }
}