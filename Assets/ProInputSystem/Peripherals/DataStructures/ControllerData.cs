
/** 
 * Copyright (c) 2011-2017 Fernando Holguin Weber , and Studio Libeccio - All Rights Reserved
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of the ProInputSystem 
 * and associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute,
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial 
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
 * NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 * Fernando Holgu�n Weber, <contact@fernhw.com>,<http://fernhw.com>,<@fern_hw>
 * Studio Libeccio, <@studiolibeccio> <studiolibeccio.com>
 * 
 */
 
namespace ProInputSystem {
    //Controller button layout
    public class ControllerData {
       public int controllerIndex = 0;
       public string name = "";
       public IButton 
            upDpad,
            downDpad,
            leftDpad,
            rightDpad,
            xAxisJoystickLeft,
            yAxisJoystickLeft,
            xAxisJoystickRight,
            yAxisJoystickRight,  
            a,
            b,
            x,
            y,
            l,
            r,
            l2,
            r2,
            jClickLeft,
            jClickRight,
            start,
            select,
        //Extra
            leftJoystickToggle,
            rightJoystickToggle,
            altA ;
}
}