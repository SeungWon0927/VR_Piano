using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.Video;

// Show off all the Debug UI components.
public class DebugUI360 : MonoBehaviour
{
    bool inMenu;
    private Text sliderText;
    private VideoPlayer player;
    //public SerializePrivateVariables timePrefab;

    public Text currentMin;
    public Text currentSec;
    public Text totalMin;
    public Text totalSec;

    public Slider volumer;
    public RectTransform slide;
    public VideoClip london;
    public VideoClip diff;
    private float backvol = 1f;
	void Start ()
    {
        player = GetComponent<VideoPlayer>();
     
        DebugUIBuilder.instance.AddLabel(" ");

        DebugUIBuilder.instance.AddDivider();
        var sliderPrefab = DebugUIBuilder.instance.AddSlider("Volume", 1.0f, 10.0f, SliderPressed, true);
        
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        Assert.AreEqual(textElementsInSlider.Length, 2, "Slider prefab format requires 2 text components (label + value)");
        sliderText = textElementsInSlider[1];
        Assert.IsNotNull(sliderText, "No text component on slider prefab");
        sliderText.text = "Volume";
        volumer = sliderPrefab.GetComponent<Slider>();
        //player.SetDirectAudioVolume(0, volumer.value);
        DebugUIBuilder.instance.AddDivider();
        DebugUIBuilder.instance.AddButton("London", London);
        DebugUIBuilder.instance.AddButton("Random", different);
      
		DebugUIBuilder.instance.AddDivider();
        DebugUIBuilder.instance.AddButton("Pause", pause);
        DebugUIBuilder.instance.AddButton("Start", play);
        DebugUIBuilder.instance.AddButton("Restart", stop);
        DebugUIBuilder.instance.AddDivider();
        //GetComponent<NativeVideoPlayer>
        // DebugUIBuilder.instance.AddRadio("Side Radio 1", "group2", delegate(Toggle t) { RadioPressed("Side Radio 1", "group2", t); }, DebugUIBuilder.DEBUG_PANE_RIGHT);
        //DebugUIBuilder.instance.AddRadio("Side Radio 2", "group2", delegate(Toggle t) { RadioPressed("Side Radio 2", "group2", t); }, DebugUIBuilder.DEBUG_PANE_RIGHT);
        
        DebugUIBuilder.instance.Show();
        inMenu = true;
	}
    public void soundSlider()
    {
        player.SetDirectAudioVolume(0, volumer.value);
        backvol = volumer.value;
        PlayerPrefs.SetFloat("backvol", backvol);

    }
    void setCurrentTime()
    {
        string min = Mathf.Floor((int)player.time / 60).ToString("00");
        string sec = ((int)player.time % 60).ToString("00");

        currentMin.text = min;
        currentSec.text = sec;
   

    }
    void setTotalTime()
    {
        string minute = Mathf.Floor((int)player.clip.length / 60).ToString("00");
        string second = ((int)player.clip.length % 60).ToString("00");

        totalMin.text = minute;
        totalSec.text = second;
    }
    public void videoSlider()
    {
        player.GetDirectAudioVolume(0);
    }
    void London()
    {
        player.clip = london;
            player.Play();
    }
    void different()
    {
        player.clip = diff;
        player.Play();
    }
    public void time()
    {
     //   player.time
    //    player.clip = file://Assets/"360_VR Master Series _ Free Download _ London On Tower Bridge";
        player.Play();
    }
    public void TogglePressed(Toggle t)
    {
        Debug.Log("Toggle pressed. Is on? "+t.isOn);
    }
    public void RadioPressed(string radioLabel, string group, Toggle t)
    {
        Debug.Log("Radio value changed: "+radioLabel+", from group "+group+". New value: "+t.isOn);
    }

    public void SliderPressed(float f)
    {
        Debug.Log("Slider: " + f);
        sliderText.text = f.ToString();
    }

    void Update()
    {
        setTotalTime();
        

        if (player.isPlaying)
        {
            setCurrentTime();

           // var time = DebugUIBuilder.instance.AddLabel("Time:  " + Mathf.FloorToInt((float)player.time));
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
        
    }

    void play()
    {
        player.Play();
    }
    void pause()
    {
        player.Pause();

    }
    void stop()
    {
        player.Stop();
    }
    void LogButtonPressed()
    {
        
    }
}
