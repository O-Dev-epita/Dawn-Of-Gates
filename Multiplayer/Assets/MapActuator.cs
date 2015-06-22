using UnityEngine;
using System.Collections;

public class MapActuator : MonoBehaviour {

	int var = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if (stream.isWriting)
        {
            int tosend = var;
            stream.Serialize(ref tosend);
        }
        else
        {
        	int received = 0;
            stream.Serialize(ref received);
            var = received;
            Debug.Log(var);
        }
    }
}
