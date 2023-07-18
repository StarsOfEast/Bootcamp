using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begin : MonoBehaviour
{
    public PlayableDirector beginTimeline;
    void Update()
    {
        if (beginTimeline.state == PlayState.Paused)
        {
            SceneManager.LoadScene("1");
        }
    }
}
