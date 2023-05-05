using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDetection : MonoBehaviour
{
    public int samplewindow = 64;
    private AudioClip micClip;
    // Start is called before the first frame update
    void Start()
    {
        MicToAudioClip();
    }
    
    public void MicToAudioClip()
    {
        string micName = Microphone.devices[0];
        micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetLoudnessfromMic()
    {
        return GetLoundnessfromAudioClip(Microphone.GetPosition(Microphone.devices[0]), micClip);
    }
    public float GetLoundnessfromAudioClip(int ClipPosition, AudioClip clip)
    {
        int StartPosition = ClipPosition - samplewindow;
        if(StartPosition < 0) { return 0; }
        float[] waveData= new float[samplewindow];
        clip.GetData(waveData, StartPosition);
        float totalLoudness = 0;
        for(int i = 0;i<samplewindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness/samplewindow;
    }
}
