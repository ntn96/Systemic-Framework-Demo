using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHit : MonoBehaviour {
    [SerializeField] GameObject sound;
    [SerializeField] GameObject sparks;
    [SerializeField] float axisYOffset = 0.5f;
    [SerializeField] bool debug = false;

    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, ~0, QueryTriggerInteraction.Ignore))
        {
            if (debug)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawRay(transform.position, Vector3.down * transform.localScale.y, Color.yellow);
            }
            Instantiate(sound, hit.point, Quaternion.identity);
            GameObject actualSparks = Instantiate(sparks);
            actualSparks.transform.position = hit.point + new Vector3(0, axisYOffset, 0);
            actualSparks.transform.parent = transform;
        }
    }
}
