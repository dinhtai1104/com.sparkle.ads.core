using System;

namespace com.sparkle.ads.core
{
    public class NullInterstitialAdapter : IInterstitialAdapter
    {
        public static readonly NullInterstitialAdapter Instance = new NullInterstitialAdapter();

        private NullInterstitialAdapter()
        {
        }

        public event Action OnLoadSucceeded;
        public event Action<AdError> OnLoadFailed;
        public event Action<AdError> OnShowFailed;
        public event Action<AdPlacement> OnShowSucceeded;
        public event Action<AdPlacement> OnClicked;
        public event Action OnClosed;
        public event Action<ImpressionData> OnImpressionSuccess;

        public bool IsReady { set; get; }

        public void Load()
        {
        }

        public void Show(AdPlacement placement)
        {
            OnClosed?.Invoke();
        }
    }
}