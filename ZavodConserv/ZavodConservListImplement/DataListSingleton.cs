﻿using System;
using System.Collections.Generic;
using System.Text;
using ZavodConservListImplement.Models;

namespace ZavodConservListImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Conserv> Conservs { get; set; }

        public List<ConservComponent> ConservComponents { get; set; }

        public List<Client> Clients { get; set; }

        public List<Implementer> Implementers { get; set; }

        public List<MessageInfo> MessageInfoes { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>(); 
            Conservs = new List<Conserv>();
            ConservComponents = new List<ConservComponent>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null) 
            { 
                instance = new DataListSingleton(); 
            }
            return instance;
        }
    }
}
