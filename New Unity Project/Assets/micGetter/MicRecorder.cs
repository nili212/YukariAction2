using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MicRecorder : MonoBehaviour
{

    public float sensitivity;

    [SerializeField]
    AudioSource audio;

    public void RecordStart()
    {
        int minFreq, maxFreq;
        Microphone.GetDeviceCaps(Microphone.devices[1], out minFreq, out maxFreq);
        audio.clip = Microphone.Start(Microphone.devices[1], true, 1, minFreq);
        audio.loop = true;
        //audio.mute = true;

        


        while (!(Microphone.GetPosition(Microphone.devices[1]) > 0)) { }


        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        audio.Play();

        this.UpdateAsObservable().Subscribe(
            _ => {
                float[] data = new float[10];
                float vol = 0;
                audio.GetOutputData(data, 0);
                for (int i = 0; i < data.Length; i++)
                {
                    vol += Mathf.Abs(data[i]);
                }
                vol /= 10f;
                if(vol>=0.01f)
                    Debug.Log("volume:" + vol);
            }
        );
    }


}
