﻿using OdeToFood.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;



namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }
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
    }
}
