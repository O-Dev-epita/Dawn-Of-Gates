using System;
using UnityEngine;

public struct PortalStruct
{
	public Vector3 pos;
	public Quaternion rot;
	public bool opened;
	
	public const int SIZE = 29;
	public const byte TYPE_LEFT = 0x3;
	public const byte TYPE_RIGHT = 0x4;
	
	
	public byte[] tobyte(byte type)
	{
		byte[] result = new byte[SIZE+1];
		result [0] = type;
		BitConverter.GetBytes(pos.x).CopyTo(result, 1);
		BitConverter.GetBytes(pos.y).CopyTo(result, 5);
		BitConverter.GetBytes(pos.z).CopyTo(result, 9);
		BitConverter.GetBytes(rot.x).CopyTo(result, 13);
		BitConverter.GetBytes(rot.y).CopyTo(result, 17);
		BitConverter.GetBytes(rot.z).CopyTo(result, 21);
		BitConverter.GetBytes(rot.w).CopyTo(result, 25);
		result [29] = opened ? (byte)1 : (byte)0;
		return result;
	}
	
	public PortalStruct(Transform transform, bool s)
	{
		pos = transform.position;
		rot = transform.rotation;
		opened = s;
	}
	
	public PortalStruct(byte[] received)
	{
		pos.x = BitConverter.ToSingle(received, 0);
		pos.y = BitConverter.ToSingle(received, 4);
		pos.z = BitConverter.ToSingle(received, 8);
		rot.x = BitConverter.ToSingle(received, 12);
		rot.y = BitConverter.ToSingle(received, 16);
		rot.z = BitConverter.ToSingle(received, 20);
		rot.w = BitConverter.ToSingle(received, 24);
		opened = received [28] == 1;
	}
}
