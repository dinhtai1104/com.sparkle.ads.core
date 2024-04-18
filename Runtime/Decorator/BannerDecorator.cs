using System;

namespace com.sparkle.ads.core
{
    public abstract class BannerDecorator : IBannerAdapter
    {
        protected IBannerAdapter Adapter { private set; get; }
        public event Action<AdError> OnLoadFailed;
        public event Action<AdPlacement> OnLoadSucceeded;
        public event Action<ImpressionData> OnImpressionSuccess;

        protected BannerDecorator(IBannerAdapter adapter)
        {
            Adapter = adapter;
            Adapter.OnLoadFailed += LoadFailedHandler;
            Adapter.OnLoadSucceeded += LoadSucceededHandler;
            Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
        }

        public virtual void Load()
        {
            Adapter.Load();
        }

        public virtual void Show()
        {
            Adapter.Show();
        }

        public virtual void Hide()
        {
            Adapter.Hide();
        }

        public void Destroy()
        {
            Adapter.Destroy();
        }

        protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
        {
            OnImpressionSuccess?.Invoke(impressionData);
        }

        protected virtual void LoadSucceededHandler(AdPlacement placement)
        {
            OnLoadSucceeded?.Invoke(placement);
        }

        protected virtual void LoadFailedHandler(AdError error)
        {
            OnLoadFailed?.Invoke(error);
        }
    }
}