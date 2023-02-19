using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    public void Play(GameObject audio) {
        var obj = Instantiate(audio);
        Destroy(obj, obj.GetComponent<AudioSource>().clip.length);
    }
}
