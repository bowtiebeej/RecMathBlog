﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecMath.Core;
using RecMath.Core.Objects;


namespace RecMath.Models
{
    public class ListViewModel
    {
        public ListViewModel(IBlogRepository blogRepository, int p)
        {
            Posts = blogRepository.Posts(p - 1, 10);
            TotalPosts = blogRepository.TotalPosts();
        }

        public ListViewModel(IBlogRepository blogRepository, string text, string type, int p)
        {
            switch (type)
            {
                case "Tag":
                    Posts = blogRepository.PostsForTag(text, p - 1, 10);
                    TotalPosts = blogRepository.TotalPostsForTag(text);
                    Tag = blogRepository.Tag(text);
                    break;
                case "Category":
                    Posts = blogRepository.PostsForCategory(text, p - 1, 10);
                    TotalPosts = blogRepository.TotalPostsForCategory(text);
                    Category = blogRepository.Category(text);
                    break;
                case "Search":
                    Posts = blogRepository.PostsForSearch(text, p - 1, 10);
                    TotalPosts = blogRepository.TotalPostsForSearch(text);
                    Search = text;
                    break;
                default:                
                    Posts = blogRepository.Posts(p - 1, 10);
                    break;
            }

        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set; }
        public Tag Tag { get; private set; }
        public string Search { get; private set; }
    }
}