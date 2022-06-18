using UnityEngine;
using Services.Analytics.UnityAnalytics;

namespace Services.Analytics
{
    internal interface IAnalyticsManager
    {
        void SendLevelStarted();
        void SendTransaction(string productId, decimal amount, string currency);
        void SendLevelstarted();
    }
    internal class AnalyticsManager : MonoBehaviour
    {
        private IAnalyticsService[] _services;


        private void Awake() =>
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService()
            };


        public void SendMainMenuOpened() =>
            SendEvent("MainMenuOpened");
        public void SendLevelStarted() =>
            SendEvent("Level Started");
        public void SendTransaction(string productId, decimal amount, string currency)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendTransaction(productId, amount, currency);
            Debug.Log($"Sent transaction {productId}");
        }

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
        }
    }
}
