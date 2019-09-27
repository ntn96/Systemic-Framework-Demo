using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemicDesign;

public class Inflamable : MonoBehaviour {
    [SerializeField] bool enLlamas = false;
    [SerializeField] OutputPresence presencia;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject sistemaFuego;
    [SerializeField] float extraRandomTime = 3f;

	public void Quemar(float time)
    {
        if (enLlamas) return;
        enLlamas = true;
        presencia.Stimulus = "Fuego";//Stimulus.Fuego;
        StartCoroutine(StartBurning(time));
        
    }


    IEnumerator StartBurning(float time)
    {
        yield return new WaitForSeconds(time + Random.Range(0, extraRandomTime));
        GameObject nuevoFuego = Instantiate(fuego, transform);
        nuevoFuego.transform.localPosition = new Vector3(0,0.5f,0);
        nuevoFuego.transform.parent = sistemaFuego.transform;
        nuevoFuego.GetComponent<ParticleSystem>().Play();
    }
}
