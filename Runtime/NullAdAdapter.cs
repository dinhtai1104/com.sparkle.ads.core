using System;

namespace com.sparkle.ads.core
{
    public class NullAdAdapter : IAdAdapter
    {
        public IBannerAdapter Banner { private set; get; }
        public IInterstitialAdapter Interstitial { private set; get; }
        public IRewardVideoAdapter RewardVideo { private set; get; }
        public IAppOpenAdapter AppOpen { private set; get; }

        public NullAdAdapter()
        {
            Banner = NullBannerAdapter.Instance;
            Interstitial = NullInterstitialAdapter.Instance;
            RewardVideo = NullRewardVideoAdapter.Instance;
            AppOpen = NullAppOpenAdapter.Instance;
        }

        public void Initialize(Action<bool> onComplete)
        {
            onComplete?.Invoke(true);
        }

        public void SetPause(bool pause)
        {
        }

        public void SetBanner(IBannerAdapter bannerAdapter)
        {
            Banner = bannerAdapter;
        }

        public void SetInterstitial(IInterstitialAdapter interstitialAdapter)
        {
            Interstitial = interstitialAdapter;
        }

        public void SetRewardVideo(IRewardVideoAdapter rewardVideoAdapter)
        {
            RewardVideo = rewardVideoAdapter;
        }

        public void SetAppOpen(IAppOpenAdapter appOpenAdapter)
        {
            AppOpen = appOpenAdapter;
        }
    }
}