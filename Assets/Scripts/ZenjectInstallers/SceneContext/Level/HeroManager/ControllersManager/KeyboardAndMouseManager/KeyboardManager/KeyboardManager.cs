using UnityEngine;

namespace Fight.Level.Characters.Heroes.Controllers.KeyboardAndMouse.Keyboard
{
    public class KeyboardManager
    {
        public readonly Data data = new Data();


        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.W))
                data.SetPressedForward(true);
            else if (Input.GetKeyUp(KeyCode.W))
                data.SetPressedForward(false);

            if (Input.GetKeyDown(KeyCode.S))
                data.SetPressedBack(true);
            else if (Input.GetKeyUp(KeyCode.S))
                data.SetPressedBack(false);

            if (Input.GetKeyDown(KeyCode.A))
                data.SetPressedLeft(true);
            else if (Input.GetKeyUp(KeyCode.A))
                data.SetPressedLeft(false);

            if (Input.GetKeyDown(KeyCode.D))
                data.SetPressedRight(true);
            else if (Input.GetKeyUp(KeyCode.D))
                data.SetPressedRight(false);

            if (Input.GetKeyDown(KeyCode.LeftShift))
                data.SetPressedRun(true);
            else if (Input.GetKeyUp(KeyCode.LeftShift))
                data.SetPressedRun(false);
        }
    }
}