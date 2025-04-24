namespace CreationalDesignPatterns.Factory.AsyncFactory
{
    public class Foo{
        int x;

        private Foo(){}

        private async Task<Foo> InitFoo(){
            await Task.Delay(1000);
            x = 42;
            return new Foo();
        }

        public static async Task<Foo> CreateAsync(int y){
            var foo = new Foo();
            await foo.InitFoo();
            foo.x = foo.x * y;
            return foo;
        }

        public override string ToString(){
            return $"Foo: {x}";
        }

    }
}