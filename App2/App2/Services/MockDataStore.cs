﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App2.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App2.Services.MockDataStore))]
namespace App2.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Chocolate", Description="3 capas." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Vainilla", Description="para el biscocho" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Pisos", Description="3 pisos de alto" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Forma", Description="forma de estrella." },
                
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}