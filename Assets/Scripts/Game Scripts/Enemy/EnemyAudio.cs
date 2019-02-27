using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {

    private AudioSource audio_Source;

    [SerializeField]
    private AudioClip[] scream_clip, die_clip;

    [SerializeField]
    private AudioClip[] attack_clip;

    private void Awake()
    {
        audio_Source = GetComponent<AudioSource>();
    }

    public void Play_ScreamClip()
    {
        audio_Source.clip = scream_clip[Random.Range(0, scream_clip.Length)];
        audio_Source.Play();
    }

    public void Play_DeadClip()
    {
        audio_Source.clip = die_clip[Random.Range(0, die_clip.Length)];
        audio_Source.Play();
    }

    public void Play_AttackClip()
    {
        audio_Source.clip = attack_clip[Random.Range(0, attack_clip.Length)];
        audio_Source.Play();
    }
}
