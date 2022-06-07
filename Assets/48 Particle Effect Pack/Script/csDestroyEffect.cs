using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 2);
    }
	void Update () {
      //      Destroy(gameObject);
      //  if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
      //  {
      //  }
    }
}
