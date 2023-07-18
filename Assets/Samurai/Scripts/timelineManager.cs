using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StarterAssets;

public class timelineManager : MonoBehaviour
{
    public PlayableDirector timeline1;
    private bool isTimeline1Finished = false;
    public GameObject player;

    private void Update()
    {
        if (timeline1.state == PlayState.Paused && !isTimeline1Finished)
        {
            isTimeline1Finished = true;
            player.SetActive(true);
        }
    }
}
