using System;

namespace com.sparkle.ads.core
{
    public abstract class InterstitialDecorator : IInterstitialAdapter
    {
        protected IInterstitialAdapter Adapter { private set; get; }
        public event Action OnLoadSucceeded;
        public event Action<AdError> OnLoadFailed;
        public event Action<AdError> OnShowFailed;
        public event Action<AdPlacement> OnShowSucceeded;
        public event Action<AdPlacement> OnClicked;
        public event Action OnClosed;
        public event Action<ImpressionData> OnImpressionSuccess;
        public bool IsReady => Adapter.IsReady;

        protected InterstitialDecorator(IInterstitialAdapter adapter)
        {
            Adapter = adapter;
            Adapter.OnLoadFailed += LoadFailedHandler;
            Adapter.OnShowFailed += ShowFailedHandler;
            Adapter.OnShowSucceeded += ShowSucceededHandler;
            Adapter.OnClicked += ClickHandler;
            Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
            Adapter.OnLoadSucceeded += LoadSucceededHandler;
            Adapter.OnClosed += ClosedHandler;
        }

        protected virtual void ClickHandler(AdPlacement placement)
        {
            OnClicked?.Invoke(placement);
        }

        protected virtual void ClosedHandler()
        {
            OnClosed?.Invoke();
        }

        protected virtual void LoadSucceededHandler()
        {
            OnLoadSucceeded?.Invoke();
        }

        protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
        {
            OnImpressionSuccess?.Invoke(impressionData);
        }

        protected virtual void ShowSucceededHandler(AdPlacement placement)
        {
            OnShowSucceeded?.Invoke(placement);
        }

        protected virtual void ShowFailedHandler(AdError error)
        {
            OnShowFailed?.Invoke(error);
        }

        protected virtual void LoadFailedHandler(AdError error)
        {
            OnLoadFailed?.Invoke(error);
        }

        public virtual void Load()
        {
            Adapter.Load();
        }

        public virtual void Show(AdPlacement placement)
        {
            Adapter.Show(placement);
        }
    }
}