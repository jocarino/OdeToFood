using OdeToFood.Core;
using System;
using System.Linq;
using System.Collections.Generic;



namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Primeiro", Location = "loc1", Cusine = CusineType.Indian},
                new Restaurant { Id = 2, Name = "Segundo", Location = "loc2", Cusine = CusineType.Mexican},
                new Restaurant { Id = 3, Name = "Terceiro", Location = "loc3", Cusine = CusineType.None }

            }; 
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cusine = updatedRestaurant.Cusine;
            }
            return restaurant;
        }

        public int Commit() 
        {
            return 0;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }

        public Restaurant Detele(int id)
        {
            var restaunt = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaunt != null)
            {
                restaurants.Remove(restaunt);
            }
            return restaunt;
        }
    }
}
