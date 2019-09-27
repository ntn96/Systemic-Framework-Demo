using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemicDesign;

public class PlayerEntidad : MonoBehaviour {

	public void AbrirSuCorazon(string mensaje)
    {
        Debug.Log("El personaje siente " + mensaje);
    }

    public void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.O))
        {
            RootSystem.Instance.SendDirectStimulus("No Oxigeno");
            Debug.Log("El personaje ha usado su superpoder de quitar todo el oxigeno ");
        }
    }
}
