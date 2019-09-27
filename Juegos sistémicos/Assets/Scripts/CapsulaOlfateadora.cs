using System.Collections;
using System.Collections.Generic;
using SystemicDesign;
using UnityEngine;

public class CapsulaOlfateadora : MonoBehaviour {
    [SerializeField] Material material;
    [SerializeField] SystemicDesign.Input periodic;

    private void Start()
    {
        periodic.Activated = false;
        material.color = Color.green;
    }

    public void CaptadoOlor()
    {
        Debug.Log("La capsula olfateadora ha captado un olor");
        material.color = Color.red;
        periodic.Activated = true;
    }

    public void PerdidoRastro()
    {
        Debug.Log("La capsula olfateadora ha perdido el rastro");
        material.color = Color.green;
        periodic.Activated = false;
    }
}
