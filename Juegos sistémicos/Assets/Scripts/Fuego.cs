using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour {
    [SerializeField] int estimulosAgua = 0;
    [SerializeField] int estimuloHastaApagar = 500;
    [SerializeField] ParticleSystem fuego;
    bool bajoAgua = false;
    int cantidadAgua = 0;

	public void AplicarAgua(int agua)
    {
        bajoAgua = true;
        cantidadAgua = agua;
    }

    public void DejarDeAplicarAgua()
    {
        bajoAgua = false;
        cantidadAgua = 0;
    }

    private void Update()
    {
        if (bajoAgua)
        {
            estimulosAgua += cantidadAgua;
            if (estimulosAgua > estimuloHastaApagar)
            {
                Extinguir(5f);
            }
        }
    }

    public void Extinguir(float time)
    {
        fuego.Stop();
        Destroy(gameObject, time);
    }

    public void Reavivar(int reavivado)
    {
        if(!bajoAgua) estimulosAgua = Mathf.Max(0, estimulosAgua - reavivado);
    }
}
