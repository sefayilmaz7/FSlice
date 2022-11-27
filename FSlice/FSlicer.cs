using System.Collections;
using UnityEngine;
using BzKovSoft.ObjectSlicer.Samples;

public class FSlicer : MonoBehaviour
{
	public int SliceID { get; private set; }

	public void BeginNewSlice()
	{
		SliceID = SliceIdProvider.GetNewSliceId();
	}
}