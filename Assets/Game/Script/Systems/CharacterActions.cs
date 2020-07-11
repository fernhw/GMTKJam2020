

/// <summary>
/// All character actions worked from here
/// </summary>

public class CharacterActions
{
    public static void Parse (World world, Deltas delta, InputsManager controls) {


        world.penguinObj.GameUpdate(delta, controls);
        

    }
}
