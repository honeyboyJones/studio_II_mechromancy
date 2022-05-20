using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UnderwaterZone : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            UnderwaterAudio.instance.zoneCounter += 1;
            UnderwaterAudio.instance.UpdateAudioZone();
        }
    }

    void OnTriggerExit(Collider player)
    {
        if(player.tag == UnderwaterAudio.instance.PlayerTag)
        {
            UnderwaterAudio.instance.zoneCounter -= 1;
            UnderwaterAudio.instance.UpdateAudioZone();
        }
    }
}
