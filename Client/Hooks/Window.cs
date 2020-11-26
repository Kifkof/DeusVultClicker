using Microsoft.JSInterop;
using System;

namespace DeusVultClicker.Client.Hooks
{
    public static class Window
    {
        public static event EventHandler OnBlur;
        
        [JSInvokable("onBlurHook")]
        public static void OnBlurHook()
        {
            OnBlur?.Invoke(null, EventArgs.Empty);
        }
    }
}
