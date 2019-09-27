using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemicDesign;

enum LluviaState { Sunny, Cloudy, Raining };

public class Lluvia : MonoBehaviour {
    [SerializeField] bool debug = false;
    [SerializeField] LluviaState state = LluviaState.Sunny;
    [SerializeField] ParticleSystem clouds;
    [SerializeField] ParticleSystem rain;
    [SerializeField] Output output;
    [SerializeField] OutputDirectConnection directOutput;
    [Header("Rayos")]
    [SerializeField] GameObject lightning;
    [SerializeField] float lightningZoneRadius = 20f;
    [SerializeField] Vector3 lightningHit;

    private void Start()
    {
        if (state == LluviaState.Raining)
        {
            clouds.Play();
            rain.Play();
            output.Activated = true;
        }
    }

    public void Llover(string message)
    {
        if(debug) Debug.Log("llueve "+Time.time+" "+message);
    }

    public void ChangeWeather()
    {
        directOutput.SendStimulus(0);
        switch (state)
        {
            case LluviaState.Sunny:
                clouds.Play();
                state = LluviaState.Cloudy;
                break;
            case LluviaState.Cloudy:
                if (Random.value > 0.5f)
                {
                    rain.Play();
                    output.Activated = true;
                    state = LluviaState.Raining;
                } else
                {
                    clouds.Stop();
                    state = LluviaState.Sunny;
                }
                break;
            case LluviaState.Raining:
                rain.Stop();
                output.Activated = false;
                state = LluviaState.Cloudy;
                break;
        }
        if (debug) Debug.Log(state);
    }

    public void Lightning()
    {
        if (state != LluviaState.Sunny)
        {
            Vector3 position = (new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f))).normalized;
            position = position * Random.Range(0, lightningZoneRadius) + lightningHit;
            Instantiate(lightning, transform).transform.position = position;
        } 
    }
}
