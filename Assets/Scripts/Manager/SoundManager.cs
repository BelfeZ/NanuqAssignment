using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("BGM Materials")]
    [SerializeField] private AudioClip[] bgmSoundList;

    [Header("VFX Materials")]
    [SerializeField] private AudioClip[] vfxSoundList;
    [Space(5)]
    [SerializeField] private AudioClip[] jumpSoundList;

    [Header("AudioSources Materials")]
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource vfx;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayVfx(int sound)
    {
        vfx.PlayOneShot(vfxSoundList[sound]);
    }

    public void PlayBgm(int sound)
    {
        bgm.clip = bgmSoundList[sound];
        bgm.Play();
    }

    public void PlayRandomJumpVfx()
    {
        int random = Random.Range(0, jumpSoundList.Length);
        vfx.PlayOneShot(jumpSoundList[random]);
    }

    public void MuteSounds(bool mute)
    {
        bgm.mute = mute;
        vfx.mute = mute;
    }
}