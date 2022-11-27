using System.Collections;
using UnityEngine;
using BzKovSoft.ObjectSlicer.Samples;
using BzKovSoft.ObjectSlicer;

abstract public class FSliceable : MonoBehaviour
{
	public GameObject sliceableCharacter;
	public SkinnedMeshRenderer skinnedMR;
	public FSlicer slicer;

	IBzSliceableNoRepeat _sliceableAsync;

	void Start()
	{
		_sliceableAsync = sliceableCharacter.GetComponent<IBzSliceableNoRepeat>();
	}

	public void Execute()
    {
		Slice(slicer);
	}

	private void Slice(FSlicer slicer)
	{
		slicer.BeginNewSlice();

		_sliceableAsync.Slice(new Plane(Vector3.up, skinnedMR.bounds.center), slicer.SliceID, result => {
			if (result.sliced)
			{
				OnSliceComplete(result);
			}
		});
	}

	abstract protected void OnSliceComplete(BzSliceTryResult result);
}