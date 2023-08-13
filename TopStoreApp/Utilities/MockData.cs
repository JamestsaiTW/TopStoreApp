﻿using System.Collections.ObjectModel;

namespace TopStoreApp.Utilities;

public class MockData : Services.IDataService
{
    private readonly ObservableCollection<Models.Person> people;
    private readonly ObservableCollection<Models.Product> goods;

    private readonly ObservableCollection<Models.Order> orders;

    public MockData()
    {
        people = new ObservableCollection<Models.Person>()
        {
            new Models.Person {Id = 1, Name = "James Tsai" , Address = "台北市信義區忠孝東路100號" , Tel = "02-22233311" , Email= "Jamestsai@abc.com.tw"},
            new Models.Person {Id = 2, Name = "Andy Kao" , Address = "新北市永和區中和路100號" , Tel = "02-77733311" , Email= "Andykao@abc.com.tw"},
            new Models.Person {Id = 3, Name = "John Chang" , Address = "新竹市東區風城路100號" , Tel = "03-33355511" , Email= "Johnchang@abc.com.tw"},
            new Models.Person {Id = 4, Name = "Da Wang" , Address = "台中市北區松江路100號" , Tel = "04-88833311" , Email= "Dawang@abc.com.tw"},
            new Models.Person {Id = 5, Name = "Mandy Q" , Address = "台南市西區中正路100號" , Tel = "06-66633311" , Email= "Mandyq@abc.com.tw"},
        };

        goods = new ObservableCollection<Models.Product>()
        {
            new Models.Product {Id = 1, Sn = "A-0001", Name = "Sample Product A-1" , Images = "tmp.png", Price = 200M, Unit = "包", Msrp = 300M, Package = 12, Note = "There is no Note" },
            new Models.Product {Id = 2, Sn = "A-0002", Name = "Sample Product A-2" , Images = "tmp.png", Price = 50M, Unit = "袋", Msrp = 80M, Package = 3, Note = "There is no Note" },
            new Models.Product {Id = 3, Sn = "B-0001", Name = "Sample Product B-101" , Images = "tmp.png", Price = 60M, Unit = "罐", Msrp = 100M, Package = 1, Note = "There is no Note" },
            new Models.Product {Id = 4, Sn = "B-0002", Name = "Sample Product B-220" , Images = "tmp.png", Price = 180M, Unit = "組", Msrp = 250M, Package = 1, Note = "There is no Note" },
            new Models.Product {Id = 5, Sn = "B-0003", Name = "Sample Product B-300" , Images = "tmp.png", Price = 45M, Unit = "瓶", Msrp = 50M, Package = 5, Note = "There is no Note" },
        };

        orders = new ObservableCollection<Models.Order> {
            new Models.Order
            {
                Id = 1,
                PersonId = 5,
                OrderDate = DateTime.Parse("2023/08/04")
            },
            new Models.Order
            {
                Id = 2,
                PersonId = 1,
                OrderDate = DateTime.Parse("2023/08/03")
            },
            new Models.Order
            {
                Id = 3,
                PersonId = 4,
                OrderDate = DateTime.Parse("2023/08/03")
            },
            new Models.Order
            {
                Id = 4,
                PersonId = 2,
                OrderDate = DateTime.Parse("2023/08/02")
            },
            new Models.Order
            {
                Id = 5,
                PersonId = 3,
                OrderDate = DateTime.Parse("2023/08/02")
            },
            new Models.Order
            {
                Id = 6,
                PersonId = 4,
                OrderDate = DateTime.Parse("2023/08/02")
            },
            new Models.Order
            {
                Id = 7,
                PersonId = 1,
                OrderDate = DateTime.Parse("2023/08/02")
            },
            new Models.Order
            {
                Id = 8,
                PersonId = 5,
                OrderDate = DateTime.Parse("2023/08/02")
            },
            new Models.Order
            {
                Id = 9,
                PersonId = 2,
                OrderDate = DateTime.Parse("2023/08/01")
            },
            new Models.Order
            {
                Id = 10,
                PersonId = 3,
                OrderDate = DateTime.Parse("2023/08/01")
            },
            new Models.Order
            {
                Id = 11,
                PersonId = 4,
                OrderDate = DateTime.Parse("2023/08/01")
            },
            new Models.Order
            {
                Id = 12,
                PersonId = 2,
                OrderDate = DateTime.Parse("2023/07/31")
            },
            new Models.Order
            {
                Id = 13,
                PersonId = 3,
                OrderDate = DateTime.Parse("2023/07/31")
            },
            new Models.Order
            {
                Id = 14,
                PersonId = 4,
                OrderDate = DateTime.Parse("2023/07/31")
            },
            new Models.Order
            {
                Id = 15,
                PersonId = 5,
                OrderDate = DateTime.Parse("2023/07/31")
            },
        };
    }

    public ObservableCollection<Models.SummaryOrder> GetSummaryOrders(DateTime? dateTime = null)
    {
        var summaryOrders = from order in orders
                    group order by order.OrderDate.Date into g
                    select new Models.SummaryOrder { Summary = g.Key, Count = g.Count() };
        return new ObservableCollection<Models.SummaryOrder>(summaryOrders);
    }

    public ObservableCollection<Models.OrderOwner> GetOrderOwners(DateTime orderDate)
    {
        var orderOwners = from order in orders
                    join person in people on order.PersonId equals person.Id
                    where order.OrderDate.Date == orderDate.Date
                    select new Models.OrderOwner { Owner = person.Name , OrderId = order.Id };

        return new ObservableCollection<Models.OrderOwner>(orderOwners);
    }

    public ObservableCollection<Models.Person> GetPeople(string keyword = "")
    {
        return new ObservableCollection<Models.Person>(people.Where<Models.Person>((person) => person.Name.ToLower().Contains(keyword.ToLower())));
    }

    public Models.Person GetPerson(int id)
    {
        return people.FirstOrDefault((person) => { return person.Id == id; });
    }

    public Models.Person NewPerson()
    {
        return new Models.Person() { Id = people.Last().Id + 1 };
    }

    public int SavePerson(Models.Person person)
    {
        if (person.Id > people.Last().Id)
            people.Add(person);
        return 1;
    }

    public int DeletePerson(Models.Person person)
    {
        return people.Remove(person) ? 1 : 0;
    }

    public ObservableCollection<Models.Product> GetGoods(string keyword = "")
    {
        return new ObservableCollection<Models.Product>(goods.Where<Models.Product>((product) => product.Name.ToLower().Contains(keyword.ToLower())));
    }

    public Models.Product GetProduct(int id)
    {
        return goods.FirstOrDefault((product) => { return product.Id == id; });
    }

    public Models.Product NewProduct()
    {
        return new Models.Product() { Id = goods.Last().Id + 1 , Images = "tmp.png" };
    }

    public int SaveProduct(Models.Product product)
    {
        if (product.Id > goods.Last().Id)
            goods.Add(product);
        return 1;
    }

    public int DeleteProduct(Models.Product product)
    {
        return goods.Remove(product) ? 1 : 0;
    }
}
