using System;

namespace OpenClosed{

	public enum Color{
		Red, Green, Blue
	}

	public enum Size {
		Small, Medium, Large, Yuge
	}

	public class Product{
		public required string name;
		public Color color;
		public Size size;

		override public string ToString(){
			return $"name: {name}\ncolor: {color}\nsize: {size}\n";
		}

	}

	public interface ISpecification<T>{
		bool IsSatisfied(T t);
	}

    public class ProductColorSpec : ISpecification<Product>
    {
        public Color color;

        public bool IsSatisfied(Product t)
        {
            return t.color == color;
        }
    }

    public class ProductSizeSpec : ISpecification<Product>
    {
		public Size size;

        public bool IsSatisfied(Product p)
        {
			return (p.size == size);
        }
    }

    public interface IFilter<T>{
		public IEnumerable<T> Filter(IEnumerable<T> items, IEnumerable<ISpecification<T>> specs);
	}

    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, IEnumerable<ISpecification<Product>> specs)
        {
            foreach(var item in items){
				var isValidItem = true;

				foreach(var spec in specs){
					if(!spec.IsSatisfied(item)){
						isValidItem = false;
						break;
					}
				}

				if(isValidItem){
					yield return item;
				}
			}
        }
    }

    public class Program {
		
		public static void Main(string[] args){
			var apple = new Product{
				name= "Apple",
				color = Color.Green,
				size = Size.Small
			};
			var tree = new Product{
				name= "Tree",
				color = Color.Green,
				size = Size.Large
			};
			var house = new Product{
				name= "House",
				color = Color.Red,
				size = Size.Yuge
			};

			Product[] products = [apple, tree, house];
			ProductFilter productFilter = new ProductFilter();
			foreach(var p in productFilter.Filter(products, [new ProductColorSpec {color=Color.Green}, new ProductSizeSpec{size=Size.Small}])){
				Console.WriteLine(p);
			}
			
		}
		
	}

}
