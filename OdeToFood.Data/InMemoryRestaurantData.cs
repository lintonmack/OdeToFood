using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> Restaurants;
        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant {
                    Id = 1,
                    Name = "Linto's Pizza",
                    Location = "Manchester",
                    Cuisine = Restaurant.CuisineType.Italian
                },
                new Restaurant {
                    Id = 2,
                    Name = "Jims Pizza",
                    Location = "Manchester",
                    Cuisine = Restaurant.CuisineType.Indian
                }
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int id)
        {
            return Restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = Restaurants.SingleOrDefault(
                r => r.Id == updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}
