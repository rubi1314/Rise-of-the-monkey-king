using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;

    private AudioSource controlAudio;

    private void Awake()
    {
        //controlAudDDDio = GetComponent<AudioSource>();
    }

    public void SeleccionAudio (int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice], volumen);
    }
}
