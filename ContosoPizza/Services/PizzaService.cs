// using ContosoPizza.Data;
// using ContosoPizza.Models;

// namespace ContosoPizza.Services
// {
//     public class PizzaService
//     {
        
//         private readonly PizzaContext _context = default!;

//         public PizzaService(PizzaContext context) 
//         {
//             _context = context;
//         }
        
//         public IList<Pizza> GetPizzas()
//         {
//             if(_context.Pizzas != null)
//             {
//                 return _context.Pizzas.ToList();
//             }
//             return new List<Pizza>();
//         }

//         public void AddPizza(Pizza pizza)
//         {
//             if (_context.Pizzas != null)
//             {
//                 _context.Pizzas.Add(pizza);
//                 _context.SaveChanges();
//             }
//         }

//         public void DeletePizza(int id)
//         {
//             if (_context.Pizzas != null)
//             {
//                 var pizza = _context.Pizzas.Find(id);
//                 if (pizza != null)
//                 {
//                     _context.Pizzas.Remove(pizza);
//                     _context.SaveChanges();
//                 }
//             }            
//         } 
//     }
// }

using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService 
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Pepperoni", IsGlutenFree = false },
            new Pizza { Id = 3, Name = "Hawaiian", IsGlutenFree = false },
            new Pizza { Id = 4, Name = "Veggie", IsGlutenFree = true },
        };
    }

public static List<Pizza> GetAll() => Pizzas;

public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

public static void Add(Pizza pizza)
{
    pizza.Id = nextId++;
    Pizzas.Add(pizza);
}

public static void Delete(int id)
{
    var pizza = Get(id);
    if (pizza is null)
        return;

    Pizzas.Remove(pizza);
}
public static void Update(Pizza pizza)
{
    var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    if (index == -1)
        return;

    Pizzas[index] = pizza;
}
}


