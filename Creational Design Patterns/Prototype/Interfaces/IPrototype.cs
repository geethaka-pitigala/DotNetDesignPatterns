namespace CreationalDesignPatterns.Prototype.Interfaces{
    public interface IPrototype<T>{
        public T DeepCopy();
    }
}