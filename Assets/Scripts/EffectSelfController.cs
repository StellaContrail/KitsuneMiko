using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSelfController : MonoBehaviour {

    public bool isDestinedToDie = false;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
        Destroy(gameObject, gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().main.duration);
    }
}
