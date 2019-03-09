using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MicRecorder : MonoBehaviour
{

    public float sensitivity;

    public UnityEngine.UI.Text buttonTex;

    public UnityEngine.UI.Dropdown drop;

    [SerializeField]
    AudioSource source;

    bool nowrecord;

    public void Start()
    {
        drop.ClearOptions();
        drop.AddOptions(new List<string>(Microphone.devices));

        this.UpdateAsObservable().Subscribe(
            _ => {
                if (!nowrecord)
                    return;
                float[] data = new float[1];
                float vol = 0;
                source.GetOutputData(data, 0);
                for (int i = 0; i < data.Length; i++)
                {
                    vol += Mathf.Abs(data[i]);
                }
                vol /= 1f;
                Debug.Log(vol);
                if (vol >= 0.001f)
                    Debug.Log("volume:" + vol);
            }
        );
    }

    public void ss()
    {
        Debug.Log(drop.options[drop.value].text);
    }

    public void RecordStart()
    {
        nowrecord = !nowrecord;
        if (!nowrecord)
        {
            buttonTex.text = "マイク録音開始";
            source.Stop();
            return;
        }

        buttonTex.text = "マイク録音終了";

        int minFreq, maxFreq;
        Microphone.GetDeviceCaps(Microphone.devices[drop.value], out minFreq, out maxFreq);
        source.clip = Microphone.Start(Microphone.devices[drop.value], true, 1, minFreq);
        source.loop = true;
        //audio.mute = true;
        
        while (!(Microphone.GetPosition(Microphone.devices[drop.value]) > 0)) { }

        source.Play();

        
    }


}
