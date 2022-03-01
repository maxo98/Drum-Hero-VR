using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MidiPlayerTK;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private MidiFilePlayer midiFilePlayer;

    [SerializeField] 
    private List<SoundPlayer> soundPlayers;

    [SerializeField] 
    private List<Animator> indicators;

    private bool _playing;
    
    private static readonly int StartAnime = Animator.StringToHash("startAnime");

    private void Start()
    {
        midiFilePlayer.OnEventNotesMidi.AddListener(NotesToPlay);
       
    }

    // Update is called once per frame
    void Update()
    {
        StartSong();
    }
    
    private void StartSong()
    {
        if (!OVRInput.GetDown(OVRInput.RawButton.Start)) return;
        if (!_playing)
        {
            midiFilePlayer.MPTK_MidiIndex = 44;
            midiFilePlayer.MPTK_Play();
            _playing = true;
            foreach (var soundPlayer in soundPlayers)
            {
                soundPlayer.playSounds = false;
            }
        }
        else
        {
            midiFilePlayer.MPTK_Pause();
        }
    }

    private void NotesToPlay(List<MPTKEvent> notesEvent)
    {
        foreach (var mptkEvent in notesEvent.Where(mptkEvent => mptkEvent.Channel == 9))
        {
            //Debug.Log($"Note on Time:{mptkEvent.RealTime} millisecond  Note:{mptkEvent.Value}  Duration:{mptkEvent.Duration} millisecond  Velocity:{mptkEvent.Velocity}");
            switch (mptkEvent.Value)
            {
                case 35:
                    indicators[6].Play("KickIndicator");
                    break;
                case 38:
                case 40:
                    indicators[0].Play("SnareIndicator");
                    
                    break;
                case 44:
                case 46:
                    indicators[2].Play("HiHatIndicator");
                    break;
                case 49:
                case 57:
                    indicators[3].Play("CrashIndicator");
                    break;
                case 60:
                    indicators[4].Play("Tom1Indicator");
                    break;
            }
        }
    }
}
