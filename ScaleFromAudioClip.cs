using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale, maxScale;
    public AudioDetection detector;
    public float LoudnessSensibility = 100;
    public float threshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoundnessfromAudioClip(source.timeSamples, source.clip) *LoudnessSensibility;
        if (loudness <threshold)
        {
            loudness = 0;
        }
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
