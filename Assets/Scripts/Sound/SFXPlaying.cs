using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{

    public AudioSource Footsteps_Concrete;
    public AudioSource Footsteps_NormalWood;
    public AudioSource Select;

    public void PlayFootstepsC()
    {
        Footsteps_Concrete.Play();
    }

    public void PlayFootstepsW()
    {
        Footsteps_NormalWood.Play();
    }

    public void PlaySelect()
    {
        Select.Play();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Footsteps_Concrete.Play();
    }

}
