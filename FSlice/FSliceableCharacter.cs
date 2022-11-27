using BzKovSoft.ObjectSlicer;
using System.Collections;
using UnityEngine;

public class FSliceableCharacter : FSliceable
{
    public Vector3 upperBodyForce = new Vector3(0f, 400f, 0f);

    protected override void OnSliceComplete(BzSliceTryResult result)
    {
        var bottomPart = result.outObjectNeg;
        var topPart = result.outObjectPos;

        var rbs = result.outObjectPos.GetComponentsInChildren<Rigidbody>();

        foreach (var rb in rbs)
            rb.AddForce(upperBodyForce);
    }
}
