using System;
using UnityEngine;

public struct EnnemyStruct
{
	public Vector3 pos;
	public Quaternion rot;
	public bool animDeath;
	public bool animWalking;
	public bool animFight;
	public int index;

	public const int SIZE = 35;
	public const byte TYPE = 0x2;
	
	
	public byte[] tobyte()
	{
		byte[] result = new byte[SIZE];
		BitConverter.GetBytes(pos.x).CopyTo(result, 0);
		BitConverter.GetBytes(pos.y).CopyTo(result, 4);
		BitConverter.GetBytes(pos.z).CopyTo(result, 8);
		BitConverter.GetBytes(rot.x).CopyTo(result, 12);
		BitConverter.GetBytes(rot.y).CopyTo(result, 16);
		BitConverter.GetBytes(rot.z).CopyTo(result, 20);
		BitConverter.GetBytes(rot.w).CopyTo(result, 24);
		result [28] = animDeath ? (byte)1 : (byte)0;
		result [29] = animWalking ? (byte)1 : (byte)0;
		result [30] = animFight ? (byte)1 : (byte)0;
		BitConverter.GetBytes (index).CopyTo (result, 31);
		return result;
	}

	public EnnemyStruct(Transform transform, int i)
	{
		pos = transform.position;
		rot = transform.rotation;
		index = i;
		animDeath = false;
		animWalking = false;
		animFight = false;
	}
	
	public EnnemyStruct(byte[] received)
	{
		pos.x = BitConverter.ToSingle(received, 0);
		pos.y = BitConverter.ToSingle(received, 4);
		pos.z = BitConverter.ToSingle(received, 8);
		rot.x = BitConverter.ToSingle(received, 12);
		rot.y = BitConverter.ToSingle(received, 16);
		rot.z = BitConverter.ToSingle(received, 20);
		rot.w = BitConverter.ToSingle(received, 24);
		animDeath = received [28] == 1;
		animWalking = received [29] == 1;
		animFight = received [30] == 1;
		index = BitConverter.ToInt32 (received, 31);
	}
}
