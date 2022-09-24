using QuoteFetcher.DTO;
using static System.String;

namespace QuoteFetcher.Services.OOPS;

public class FoodRatingSystem
{
    private readonly Dictionary<string, PriorityQueue<Menu, Menu>> _cuisineToFood;

    public FoodRatingSystem(string[] foods, string[] cuisines, int[] ratings)
    {
        _cuisineToFood = new Dictionary<string, PriorityQueue<Menu, Menu>>();
        for (int index = 0; index < foods.Length; index++)
        {
            Menu menuItem = new()
            {
                Cuisine = cuisines[index],
                Food = foods[index],
                Rating = ratings[index]
            };
            if (_cuisineToFood.ContainsKey(cuisines[index]))
            {
                _cuisineToFood[cuisines[index]].Enqueue(menuItem, menuItem);
            }
            else
            {
                PriorityQueue<Menu, Menu> menu = new(Comparer<Menu>.Create((x, y) =>
                {
                    if (x.Rating == y.Rating)
                    {
                        return CompareOrdinal(x.Food, y.Food);
                    }

                    return y.Rating - x.Rating;
                }));
                menu.Enqueue(menuItem, menuItem);
                _cuisineToFood[cuisines[index]] = menu;
            }
        }
    }

    public string HighestRated(string cuisine)
    {
        if (!_cuisineToFood.ContainsKey(cuisine))
        {
            throw new Exception("Cuisine not found!");
        }

        PriorityQueue<Menu, Menu> cuisineMenu = _cuisineToFood[cuisine];
        Menu menu = cuisineMenu.Dequeue();
        _cuisineToFood[cuisine].Enqueue(menu, menu);
        return menu.Food;
    }
}
