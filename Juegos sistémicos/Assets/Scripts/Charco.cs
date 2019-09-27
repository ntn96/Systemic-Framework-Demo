using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour {
    [SerializeField] float maximo = 4f;
    [SerializeField] float velocity = 0.01f;

    [SerializeField] bool llenandose = false;
    [SerializeField] float cantidadAgua = 0;

	public void IntroducirAgua(float cantidad)
    {
        llenandose = true;
        cantidadAgua = cantidad;
    }

    public void DejarDeIntroducirAgua()
    {
        llenandose = false;
        cantidadAgua = 0;
    }

    private void Update()
    {
        if (llenandose)
        {
            float altura = transform.localScale.y;
            float nuevaAltura = Mathf.Clamp(altura + cantidadAgua * Time.deltaTime * velocity, 0, maximo);
            transform.localScale = new Vector3(transform.localScale.x, nuevaAltura, transform.localScale.z);
        }
        
    }
}
