using System;
using UnityEngine;

public struct PersoStruct
{
	public Vector3 pos;
	public Quaternion rot;
	
	
	public byte[] tobyte()
	{
		byte[] result = new byte[38];
		BitConverter.GetBytes(pos.x).CopyTo(result, 0);
		BitConverter.GetBytes(pos.y).CopyTo(result, 4);
		BitConverter.GetBytes(pos.z).CopyTo(result, 8);
		BitConverter.GetBytes(rot.x).CopyTo(result, 12);
		BitConverter.GetBytes(rot.y).CopyTo(result, 16);
		BitConverter.GetBytes(rot.z).CopyTo(result, 20);
		BitConverter.GetBytes(rot.w).CopyTo(result, 24);
		return result;
	}
	
	public void tostruct(byte[] received)
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
