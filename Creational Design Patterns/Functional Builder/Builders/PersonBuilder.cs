using CreationalDesignPatterns.FunctionalBuilder.Models;

namespace CreationalDesignPatterns.FunctionalBuilder.Builders
{
 public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>{
        private readonly Person _person = new Person();
        public override Person Build(){
            return this._actions.Aggregate(_person, (p, action) => action(p));
        }
    }
}