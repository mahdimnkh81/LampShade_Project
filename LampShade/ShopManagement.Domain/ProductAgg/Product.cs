﻿using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string UniPrice{ get; set; }
        public bool IsInStock { get; set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public ProductCategory Category { get; private set; }


        public Product(string name, string code, string uniPrice, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, long categoryId, string slug, string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            UniPrice = uniPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsInStock = true;
        }

        public void Edit(string name, string code, string uniPrice, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, long categoryId, string slug, string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            UniPrice = uniPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public OperationResult  InStock()
        {
            var operation = new OperationResult();
            IsInStock = true;
            return operation.Succedded();
        }
        public OperationResult NOTInStock()
        {
            var operation = new OperationResult();
            IsInStock = false;
            return operation.Failed();
        }
    }
}