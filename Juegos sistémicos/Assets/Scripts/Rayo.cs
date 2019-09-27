using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour {
    [SerializeField] float timeAlive = 0.2f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeAlive);
	}
}
