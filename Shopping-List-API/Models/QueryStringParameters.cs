using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{
    public abstract class QueryStringParameters
    {
		const int MAXPAGESIZE = 50;
		public int PageNumber { get; set; } = 1;
		private int _pageSize = 10;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value;
			}
		}
	}
}
