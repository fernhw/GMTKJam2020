

/// <summary>
/// Deletes all button presses after initiated so they only remain for that frame of action
/// </summary>
/// 
public class InputDeleter
{
    public static void Parse(ref InputsManager controls) {
        controls.actionButton = false;
        controls.click = false;
        controls.quak = false;

        // disabled but here in case we need them
        // controls.movement.x = 0;
        // controls.movement.y = 0;
        // controls.pointer.x = 0;
        // controls.pointer.y = 0;

    }
}

