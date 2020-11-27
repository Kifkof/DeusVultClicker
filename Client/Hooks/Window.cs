using Microsoft.JSInterop;
using System;
using System.ComponentModel;

namespace DeusVultClicker.Client.Hooks
{
    public static class Window
    {
        public static event EventHandler OnBlur;
        public static event EventHandler OnFocus;

        [JSInvokable("onBlurHook")]
        [Browsable(false)]
        public static void OnBlurHook()
        {
            OnBlur?.Invoke(null, EventArgs.Empty);
        }

        [JSInvokable("onFocusHook")]
        [Browsable(false)]
        public static void OnFocusHook()
        {
            OnFocus?.Invoke(null, EventArgs.Empty);
        }
    }
}
