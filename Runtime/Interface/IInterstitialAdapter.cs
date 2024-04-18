using System;

namespace com.sparkle.ads.core
{
    public interface IInterstitialAdapter
    {
        event Action<AdError> OnLoadFailed;
        event Action OnLoadSucceeded;
        event Action<AdError> OnShowFailed;
        event Action<AdPlacement> OnShowSucceeded;
        event Action<AdPlacement> OnClicked;
        event Action OnClosed;
        event Action<ImpressionData> OnImpressionSuccess;
        bool IsReady { get; }
        
        void Load();
        void Show(AdPlacement adPlacement);
    }
}