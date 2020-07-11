
using UnityEngine;

/// <summary>
/// Creates global Delta times and mods to it
/// </summary>
public class DeltaTimeSystem
{
   public static void Parse (ref Deltas delta) { 
        delta.mainDelta = Time.deltaTime;
        delta.actionDelta = Time.deltaTime /*modifier for SLOW MOTION PENGUINS*/;
    }
}
