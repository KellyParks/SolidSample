namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;

        /* Make Logger a property and default it to console logger, which will give us the current behaviour in production, and let us modify the property in the tests. */
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}
