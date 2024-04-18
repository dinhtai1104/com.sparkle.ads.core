namespace com.sparkle.ads.core
{
    public enum AdErrorCode
    {
        Unexpected,
        NoAdToShow,
        ServerResponseFailed,
        NoInternet,
        CannotShowWhileOtherShowing,
        CannotLoadWhileOtherShowing,
        ReachPlacementCapLimit,
        ReachAdUnitDailyCapLimit
    }
}