namespace CreationalDesignPatterns.FunctionalBuilder.Builders{
        public abstract class FunctionalBuilder<T, TSelf> where TSelf : FunctionalBuilder<T, TSelf>{
        protected List<Func<T, T>> _actions = new List<Func<T, T>>();

        public TSelf AddAction(Func<T, T> action)
        {
            _actions.Add(action);
            return (TSelf) this; 
        }

        public abstract T Build();
    }
}