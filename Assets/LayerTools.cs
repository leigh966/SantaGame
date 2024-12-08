using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerTools
{
    public static bool LayerInMask(int layer, LayerMask mask)
    {
        return (mask & (1 << layer)) != 0;
    }
}