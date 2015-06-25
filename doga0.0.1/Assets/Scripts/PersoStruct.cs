using System;
using UnityEngine;

public struct PersoStruct
{
	public Vector3 pos;
	public Quaternion rot;

	public const int SIZE = 28;
	public const byte TYPE = 0x1;

	
	public byte[] tobyte()
	{
		byte[] result = new byte[SIZE+1];
		result [0] = TYPE;
		BitConverter.GetBytes(pos.x).CopyTo(result, 1);
		BitConverter.GetBytes(pos.y).CopyTo(result, 5);
		BitConverter.GetBytes(pos.z).CopyTo(result, 9);
		BitConverter.GetBytes(rot.x).CopyTo(result, 13);
		BitConverter.GetBytes(rot.y).CopyTo(result, 17);
		BitConverter.GetBytes(rot.z).CopyTo(result, 21);
		BitConverter.GetBytes(rot.w).CopyTo(result, 25);
		return result;
	}

	public PersoStruct(Transform transform)
	{
		pos = transform.position;
		rot = transform.rotation;
	}

	public PersoStruct(byte[] received)
	{
		pos.x = BitConverter.ToSingle(received, 0);
		pos.y = BitConverter.ToSingle(received, 4);
		pos.z = BitConverter.ToSingle(received, 8);
		rot.x = BitConverter.ToSingle(received, 12);
		rot.y = BitConverter.ToSingle(received, 16);
		rot.z = BitConverter.ToSingle(received, 20);
		rot.w = BitConverter.ToSingle(received, 24);
	}
}
