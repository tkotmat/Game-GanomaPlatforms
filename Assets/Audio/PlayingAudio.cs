using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingAudio : Sounds
{
    public void Audio()
    {
        PlaySound(sounds[0], p1: 2f, p2: 1f);
    }
}
