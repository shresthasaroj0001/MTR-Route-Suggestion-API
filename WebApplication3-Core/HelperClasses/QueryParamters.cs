﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.HelperClasses
{
    public class QueryParamters
    {
        const int _maxSize = 100;
        private int _size = 10;

        public int Page { get; set; }
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
        public string SortBy { get; set; } = "Id";
        private string _sortOrder = "asc";
        public string SortOrder
        {
            get
            {
                return _sortOrder;
            }
            set
            {
                if (value == "asc" || value == "desc")
                    _sortOrder = value;
            }
        }
    }
}
