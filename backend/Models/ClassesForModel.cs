
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace backend.ClassesForModel {

        public class Product
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int ProductSizeId { get; set; }   //Done // F1
        public ProductSize ProductSize { get; set; }  //Many to One
        public int Amount { get; set; }
        public Discount Discount {get; set;} //One to One
        public ProductSold ProductSold {get; set;}
        public ICollection<WishListProduct> WishListProducts {get; set;}  //One to Many
        public ICollection<ProductCategory> Categories { get; set; }  // One To Many

    }
    public class ProductSize
    {
        [Key]
        public int Id { get; set; }
        public int SizeName {get; set;}
        public ICollection<Product> Products {get;set;} // One To Many
    }
        public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }  //F1
        public int CategoryId {get; set;}
        public Category Category { get; set;}  //F2 
    }
        public class Category
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<ProductCategory> Products { get; set; }
    }
        public class Discount
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; } //F1
        public float DiscountPercentage {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public ICollection<ProductSold> ProductsSold {get; set;}
        
    }
        public class ProductSold
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product{get; set;} // F1
        public int Amount {get; set;}
        public int UserId {get; set;}
        public  User User {get;set;}  // F2
        public DateTime Date{get; set;}
        public int OrderId {get; set;}
        public  Order Order {get;set; }  //F3
        public int DiscountId {get; set;}
        public  Discount Discount {get; set;}  //F4

    }
        public class Order  //Done
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public  User User {get;set; }  //F1
        public int StatusId {get; set;}
        public  Status Status {get;set; } //F2     
        public int AddressId {get; set; }
        public  Address Address {get;set; } //F3
        public ICollection<ProductSold> ProductsSold {get; set;}

    }
        public class User //Done
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email {get; set;}
        [StringLength(100)]
        public string Password {get; set;}
        [StringLength(10)]
        public string Salt {get; set;}
        [StringLength(15)]
        public string Ip {get; set;}
        public int Rank {get; set;}
        public ICollection<ProductSold> ProductsSold{get;set;}
        public ICollection<Order> Orders {get;set;}
        public ICollection<WishListProduct> WishListProducts {get;set;}
        public ICollection<Address> Addresses {get;set; }
        
    }
        public class Status //Done
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description {get; set;}
        public ICollection<Order> Order {get; set;}
    }
        public class WishListProduct
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User {get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
    }
        public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User {get; set;}
        [StringLength(10)]
        public string PostalCode {get; set;}
        [StringLength(100)]
        public string Street {get; set;}
        [StringLength(100)]
        public string City {get; set;}
        public int CountryId {get; set;}
        public Country Country {get; set;}
        public ICollection<Order> Orders {get; set;}
    }
        public class Country
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<Address> Addresses {get; set;}
    }
}