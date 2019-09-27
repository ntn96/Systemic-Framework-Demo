using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {
    [SerializeField] AudioSource sound;
    [SerializeField] Transform parent;
    [SerializeField] float timeAlive = 5f;

	// Use this for initialization
	void Start () {
        transform.parent = parent;
        sound.Play();
        Destroy(gameObject,timeAlive);
	}
}
