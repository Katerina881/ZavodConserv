﻿using System;
using System.Collections.Generic;
using ZavodConservbusinessLogic.BindingModels;
using ZavodConservbusinessLogic.Interfaces;
using ZavodConservbusinessLogic.ViewModels;
using ZavodConservFileImplement.Models;
using System.Linq;

namespace ZavodConservFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;

        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order element; 
            if (model.Id.HasValue)
            {
                element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec =>
               rec.Id) : 0;
                element = new Order { Id = maxId + 1 };
                source.Orders.Add(element);
            }

            element.Status = model.Status;
            element.ConservId = model.ConservId == 0 ? element.ConservId : model.ConservId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
        }

        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                Count = rec.Count,
                ConservName = GetConservName(rec.ConservId),
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                ConservId = rec.ConservId,
                Status = rec.Status,
                Sum = rec.Sum
            })
            .ToList();
        }

        private string GetConservName(int id)
        {
            string name = "";
            var conserv = source.Conservs.FirstOrDefault(x => x.Id == id);
            name = conserv != null ? conserv.ConservName : "";
            return name;
        }
    }
}
