using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    public static AudioManager _instance;
    public AudioClip collectibleClip;
	// Use this for initialization
	void Start () {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayCollectible()
    {
        AudioSource.PlayClipAtPoint(collectibleClip,Vector3.zero);
    }
}
