using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchFood
{
    public class PlayMusicHub : MonoBehaviour
    {
        public AudioClip[] audioClips;

        private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;   //播放器为循环播放模式
        }

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="contrller">播放哪个过程的bgm,首字母大写</param>
        public void PlayMusic(string contrller)
        {
            switch (contrller)
            {
                case "Start":
                    audioSource.PlayOneShot(audioClips[0]);
                    break;
                case "Game":
                    audioSource.PlayOneShot(audioClips[1]);
                    break;
            }
        }

        /// <summary>
        /// 停止播放音乐
        /// </summary>
        public void StopMusic()
        {
            audioSource.Stop();
        }
    }
}
