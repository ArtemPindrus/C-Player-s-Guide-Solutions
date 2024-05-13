namespace TheLambdaSieve {
    internal class LambdaSieve {
        private readonly Predicate<int> numberFilter;

        public LambdaSieve(Predicate<int> numberFilter) { 
            this.numberFilter = numberFilter;
        }

        public bool IsGood(int number) => numberFilter(number);
    }
}
