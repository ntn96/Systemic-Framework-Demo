using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameCounter : MonoBehaviour {
    int frameCounter = 0;
    float timeCounter = 0f;
    float lastFramerate = 0f;
    [SerializeField] float refreshTime = 0.5f;
    [SerializeField] Text text;

	// Update is called once per frame
	void Update () {
		if (timeCounter < refreshTime)
        {
            timeCounter += Time.deltaTime;
            frameCounter++;
        } else
        {
            lastFramerate = (float)frameCounter / timeCounter;
            text.text = Mathf.RoundToInt(lastFramerate).ToString();
            frameCounter = 0;
            timeCounter = 0f;
        }
	}
}
