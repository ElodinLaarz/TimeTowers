using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    [Header("Time Text")]
    public float current_time = 100;
    public Text time_text;

    // [Header("Related Things?")]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current_time -= Time.deltaTime;
        time_text.text = "Time : " + (int) current_time;
        
    }

    public void RemoveTime(){
        current_time -= 10; 
    }
}
