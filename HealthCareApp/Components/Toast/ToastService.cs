﻿using System;
using System.Timers;
using MyApp.Settings.Enum;

namespace MyApp.Components.Toast
{
    public class ToastService : IToastService, IDisposable
    {
        public event Action<string, Level>? OnShow;
        public event Action? OnHide;
        private System.Timers.Timer? Countdown { get; set; }

        public ToastService()
        {
        }

        public void ShowToast(string message, Level level)
        {
            OnShow?.Invoke(message, level);
            StartCountDown();
        }

        private void StartCountDown()
        {
            SetCountDown();
            if (Countdown is not null && Countdown.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown?.Start();
            }
        }

        private void SetCountDown()
        {
            if (Countdown == null)
            {
                Countdown = new System.Timers.Timer(2500);
                Countdown.Elapsed += HideToast;
                Countdown.AutoReset = false;
            }
        }

        private void HideToast(object? source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            Countdown?.Dispose();
        }

    }
}
