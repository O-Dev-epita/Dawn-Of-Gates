using System;
using UnityEngine;

public struct TriggerStruct
{
	public bool[] triggers;

	
	public const int SIZE = 10;
	public const byte TYPE = 5;
	
	
	public byte[] tobyte()
	{
		byte[] result = new byte[SIZE+1];
		result [0] = TYPE;
		for(int i = 0; i < SIZE; i++)
		{
			result[i+1] = triggers[i] ? (byte) 1 : (byte) 0;
		}
		return result;
	}
	
	public TriggerStruct(int lol)
	{
		triggers = new bool[SIZE];
		for(int i = 0; i < SIZE; i++)
		{
			triggers[i] = false;
		}
	}
	
	public TriggerStruct(byte[] received)
	{
		triggers = new bool[SIZE];
		for(int i = 0; i < SIZE; i++)
		{
			triggers[i] = received[i] == 1;
		}
	}
}

