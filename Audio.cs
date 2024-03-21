using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public Transform player;

    public float maxDistance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        float volume = 1f - Mathf.Clamp01(distance/maxDistance);

        source.volume = volume;
    }
}
