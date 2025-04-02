using System;

namespace NinjaTrader.Custom.AddOns.Test
{
    public static class EventManager
    {
        public static void InvokeEvent<T>(Action<T> eventHandler, T arg)
        {
            try
            {
                eventHandler?.Invoke(arg);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error invoking event: {ex.Message}", ex);
            }
        }
    }

    public static class TestEvents
    {
        public static event Action<string> OnSendToTest1;
        public static event Action<string> OnSendToTest2;

        public static void SendToTest1(string value)
        {
            EventManager.InvokeEvent(OnSendToTest1, value);
        }

        public static void SendToTest2(string value)
        {
            EventManager.InvokeEvent(OnSendToTest2, value);
        }
    }
}
